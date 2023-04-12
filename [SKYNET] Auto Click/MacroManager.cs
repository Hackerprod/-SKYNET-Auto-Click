using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using SKYNET.Hook;

namespace SKYNET
{
    public class MacroManager
    {
        public Dictionary<int, MouseEvent> Record;
        public int Step;

        private System.Timers.Timer _timer;
        private bool isRecording;
        private int currentStep;
        private MouseMessages currentClicked;
        private KeyPressed currentKey;
        private MouseHook MouseHook;
        private KeyboardHook keyboardHook;
        private int finishedInterval;

        public bool HaveRecordedMacro 
        {
            get
            {
                return Record.Count > 0;
            }
        }

        public MacroManager()
        {
            Record = new Dictionary<int, MouseEvent>();

            MouseHook = new MouseHook();
            MouseHook.OnMouseEvent += Hook_OnMouseEvent;

            keyboardHook = new KeyboardHook();
            keyboardHook.KeyDown += keyboardHook_KeyDown;
            keyboardHook.KeyUp += KeyboardHook_KeyUp;

            _timer = new System.Timers.Timer();
            _timer.AutoReset = false;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Interval = 5;

            Step = 1;
            currentStep = 1;
            currentClicked = MouseMessages.None;
        }

        private void Hook_OnMouseEvent(object sender, MouseHook.MouseEvent e)
        {
            currentClicked = e.EventType;
        }

        private void keyboardHook_KeyDown(KeyboardHook.VKeys key)
        {
            currentKey = new KeyPressed((Keys)key, KeyAction.KeyDown);
        }

        private void KeyboardHook_KeyUp(KeyboardHook.VKeys key)
        {
            currentKey = new KeyPressed((Keys)key, KeyAction.KeyUp);
        }

        public int Duration()
        {
            return Record.Count * 10;
        }

        public void StartRecording()
        {
            currentClicked = MouseMessages.None;
            _timer.Interval = 5;
            MouseHook.Install();
            keyboardHook.Install();
            Step = 1;
            isRecording = true;
            Record.Clear();
            _timer.Start();
        }

        public void StopRecording()
        {
            currentClicked = MouseMessages.None;
            _timer.Stop();
            MouseHook.Uninstall();
            keyboardHook.Uninstall();
        }

        public void StartMacro(int MacroInterval)
        {
            isRecording = false;
            finishedInterval = MacroInterval;
            _timer.Start();
        }

        public void StopMacro()
        {
            _timer.Stop();
            currentStep = 1;
        }

        private async void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (isRecording)
            {
                try
                {
                    NativeMethods.GetCursorPos(out POINT p);
                    var Event = new MouseEvent(p, currentClicked);
                    if (currentKey != null)
                    {
                        Event.Key = currentKey;
                        currentKey = null;
                    }
                    Record.Add(Step, Event);
                    currentClicked = MouseMessages.None;
                    Step += 1;
                    string time = Common.GetTime(Step * 10);
                    frmMain.frm.LB_MacroDuration.Text = time;
                    if (frmMain.Popup != null)
                    {
                        frmMain.Popup.SetTime(time);
                    }
                }
                catch 
                {
                }
            }
            else
            {
                if (currentStep < Step)
                {
                    var Event = Record[currentStep];
                    NativeMethods.SetCursorPos(Event.Point.X, Event.Point.Y);
                    switch (Event.Button)
                    {
                        case MouseMessages.ScrollUp:
                        case MouseMessages.ScrollDown:
                        case MouseMessages.WM_MOUSEWHEEL:
                            MouseHelper.SetWheel(Event.Button, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseMessages.XButton1Down:
                        case MouseMessages.XButton1Up:
                        case MouseMessages.XButton2Down:
                        case MouseMessages.XButton2Up:
                            MouseHelper.SetXClick(Event.Button, Event.Point.X, Event.Point.Y);
                            break;
                        default:
                            MouseHelper.SetClick(Event.Button, Event.Point.X, Event.Point.Y);
                            break;
                    }
                    if (Event.Key != null)
                    {
                        PressKey(Event.Key);
                    }
                    currentStep += 1;
                }
                else if (currentStep == Step && currentStep != 1)
                {
                    var Event = Record[currentStep - 1];
                    NativeMethods.SetCursorPos(Event.Point.X, Event.Point.Y);
                    switch (Event.Button)
                    {
                        case MouseMessages.ScrollUp:
                        case MouseMessages.ScrollDown:
                        case MouseMessages.WM_MOUSEWHEEL:
                            MouseHelper.SetWheel(Event.Button, Event.Point.X, Event.Point.Y);
                            break;
                        default:
                            MouseHelper.SetClick(Event.Button, Event.Point.X, Event.Point.Y);
                            break;
                    }
                    if (Event.Key != null)
                    {
                        PressKey(Event.Key);
                    }
                    currentStep = 1;
                    if (frmMain.Settings.RestartBucle)
                    {
                        var fTime = finishedInterval == 0 ? 0 : finishedInterval * 1000;
                        await AwaitTime(fTime);
                    }
                    else 
                    {
                        frmMain.StopMacro();
                        frmMain.Popup.Close();
                        return;
                    }
                }
                string time = Common.GetTime(currentStep * 10) + " / " + Common.GetTime(Step * 10);
                frmMain.frm.LB_MacroDuration.Text = time;
                if (frmMain.Popup != null)
                {
                    frmMain.Popup.SetTime(time);
                }
            }

            
            _timer.Start();
        }

        private async Task AwaitTime(int time)
        {
            await Task.Delay(time);
        }

        private void PressKey(KeyPressed key)
        {
            NativeMethods.keybd_event((byte)key.Key, 0x45, (byte)key.Action, 0);
        }
    }
}
