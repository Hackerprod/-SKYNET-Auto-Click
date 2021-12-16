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
        private MouseHook Hook;
        private MouseEvents currentClicked;
        private KeyPressed currentKey;
        private KeyboardHook keyboardHook;
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

            Hook = new MouseHook();
            Hook.LeftButtonDown += Hook_LeftButtonDown;
            Hook.LeftButtonUp += Hook_LeftButtonUp;   
            Hook.RightButtonDown += Hook_RightButtonDown;
            Hook.RightButtonUp += Hook_RightButtonUp;
            Hook.DoubleClick += Hook_DoubleClick;

            keyboardHook = new KeyboardHook();
            keyboardHook.KeyDown += keyboardHook_KeyDown;
            keyboardHook.KeyUp += KeyboardHook_KeyUp;

            _timer = new System.Timers.Timer();
            _timer.AutoReset = false;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Interval = 5;

            Step = 1;
            currentStep = 1;
            currentClicked = MouseEvents.None;
        }

        private void Hook_LeftButtonDown(object obj, MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            currentClicked = MouseEvents.LeftDown;
        }
        private void Hook_LeftButtonUp(object obj, MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            currentClicked = MouseEvents.LeftUp;
        }
        private void Hook_RightButtonDown(object obj, MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            currentClicked = MouseEvents.RightDown;
        }
        private void Hook_RightButtonUp(object obj, MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            currentClicked = MouseEvents.RightUp;
        }
        private void Hook_DoubleClick(object obj, MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            currentClicked = MouseEvents.LeftDoubleClick;
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
            currentClicked = MouseEvents.None;
            Hook.Install();
            keyboardHook.Install();
            Step = 1;
            isRecording = true;
            Record.Clear();
            _timer.Start();
        }
        public void StopRecording()
        {
            currentClicked = MouseEvents.None;
            _timer.Stop();
            Hook.Uninstall();
            keyboardHook.Uninstall();
        }
        public void StartMacro()
        {
            isRecording = false;
            _timer.Start();
        }
        public void StopMacro()
        {
            _timer.Stop();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (isRecording)
            {
                MouseHelper.GetCursorPos(out POINT p);
                var Event = new MouseEvent(p, currentClicked);
                if (currentKey != null)
                {
                    Event.Key = currentKey;
                    currentKey = null;
                }
                Record.Add(Step, Event);
                currentClicked = MouseEvents.None;
                Step += 1;
                frmMain.frm.LB_MacroDuration.Text = modCommon.GetTime(Step * 10);
            }
            else
            {
                if (currentStep < Step)
                {
                    var Event = Record[currentStep];
                    MouseHelper.SetCursorPos(Event.Point.X, Event.Point.Y);
                    switch (Event.Button)
                    {
                        case MouseEvents.LeftDown:
                            MouseHelper.SetClick(MouseEvents.LeftDown, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.LeftUp:
                            MouseHelper.SetClick(MouseEvents.LeftUp, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.RightDown:
                            MouseHelper.SetClick(MouseEvents.RightDown, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.RightUp:
                            MouseHelper.SetClick(MouseEvents.RightUp, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.LeftDoubleClick:
                            MouseHelper.SetDoubleClick(Event.Point.X, Event.Point.Y);
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
                    MouseHelper.SetCursorPos(Event.Point.X, Event.Point.Y);
                    switch (Event.Button)
                    {
                        case MouseEvents.LeftDown:
                            MouseHelper.SetClick(MouseEvents.LeftDown, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.LeftUp:
                            MouseHelper.SetClick(MouseEvents.LeftUp, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.RightDown:
                            MouseHelper.SetClick(MouseEvents.RightDown, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.RightUp:
                            MouseHelper.SetClick(MouseEvents.RightUp, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.LeftDoubleClick:
                            MouseHelper.SetDoubleClick(Event.Point.X, Event.Point.Y);
                            break;
                    }
                    if (Event.Key != null)
                    {
                        PressKey(Event.Key);
                    }
                    currentStep = 1;
                }
                frmMain.frm.LB_MacroDuration.Text = modCommon.GetTime(currentStep * 10) + " / " + modCommon.GetTime(Step * 10);
            }
            _timer.Start();

        }

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        void PressKey(Keys keyCode)
        {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            keybd_event((byte)keyCode, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event((byte)keyCode, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }
        private void PressKey(KeyPressed key)
        {
            keybd_event((byte)key.Key, 0x45, (byte)key.Action, 0);
        }
    }
}
