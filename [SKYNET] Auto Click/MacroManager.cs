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
            Hook.MiddleButtonDown += Hook_MiddleButtonDown;
            Hook.MiddleButtonUp += Hook_MiddleButtonUp;
            Hook.DoubleClick += Hook_DoubleClick;
            Hook.GamerButtonDown += Hook_GamerButtonDown;
            Hook.GamerButtonUp += Hook_GamerButtonUp;
            Hook.MouseWheel += Hook_MouseWheel;

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

        private void Hook_MouseWheel(object sender, MOUSEINPUT e)
        {
            if (e.mouseData == 7864320)
            {
                currentClicked = MouseEvents.WHEEL;
            }
            else if (e.mouseData == 4287102976)
            {
                currentClicked = MouseEvents.HWHEEL;
            }
            //frmMain.frm.LB_Tittle.Text = e.mouseData.ToString();
        }

        private void Hook_LeftButtonDown(object obj, MOUSEINPUT mouseStruct)
        {
            currentClicked = MouseEvents.LEFTDOWN;
        }
        private void Hook_LeftButtonUp(object obj, MOUSEINPUT mouseStruct)
        {
            currentClicked = MouseEvents.LEFTUP;
        }
        private void Hook_RightButtonDown(object obj, MOUSEINPUT mouseStruct)
        {
            currentClicked = MouseEvents.RIGHTDOWN;
        }
        private void Hook_RightButtonUp(object obj, MOUSEINPUT mouseStruct)
        {
            currentClicked = MouseEvents.RIGHTUP;
        }
        private void Hook_MiddleButtonDown(object sender, MOUSEINPUT e)
        {
            currentClicked = MouseEvents.MIDDLEDOWN;
        }
        private void Hook_MiddleButtonUp(object sender, MOUSEINPUT e)
        {
            currentClicked = MouseEvents.MIDDLEUP;
        }
        private void Hook_GamerButtonUp(object sender, MOUSEINPUT e)
        {
            currentClicked = MouseEvents.XDOWN;
        }
        private void Hook_GamerButtonDown(object sender, MOUSEINPUT e)
        {
            currentClicked = MouseEvents.XUP;
        }
        private void Hook_DoubleClick(object obj, MOUSEINPUT mouseStruct)
        {
            //currentClicked = MouseEvents.l;
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
            currentStep = 1;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (isRecording)
            {
                try
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
                catch 
                {
                }
            }
            else
            {
                if (currentStep < Step)
                {
                    var Event = Record[currentStep];
                    MouseHelper.SetCursorPos(Event.Point.X, Event.Point.Y);
                    switch (Event.Button)
                    {
                        case MouseEvents.LEFTDOWN:
                            MouseHelper.SetClick(MouseEvents.LEFTDOWN, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.LEFTUP:
                            MouseHelper.SetClick(MouseEvents.LEFTUP, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.RIGHTDOWN:
                            MouseHelper.SetClick(MouseEvents.RIGHTDOWN, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.RIGHTUP:
                            MouseHelper.SetClick(MouseEvents.RIGHTUP, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.MIDDLEDOWN:
                            MouseHelper.SetClick(MouseEvents.MIDDLEDOWN, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.MIDDLEUP:
                            MouseHelper.SetClick(MouseEvents.MIDDLEUP, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.WHEEL:
                            MouseHelper.SetWheel(MouseEvents.WHEEL, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.HWHEEL:
                            MouseHelper.SetWheel(MouseEvents.HWHEEL, Event.Point.X, Event.Point.Y);
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
                        case MouseEvents.LEFTDOWN:
                            MouseHelper.SetClick(MouseEvents.LEFTDOWN, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.LEFTUP:
                            MouseHelper.SetClick(MouseEvents.LEFTUP, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.RIGHTDOWN:
                            MouseHelper.SetClick(MouseEvents.RIGHTDOWN, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.RIGHTUP:
                            MouseHelper.SetClick(MouseEvents.RIGHTUP, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.MIDDLEDOWN:
                            MouseHelper.SetClick(MouseEvents.MIDDLEDOWN, Event.Point.X, Event.Point.Y);
                            break;
                        case MouseEvents.MIDDLEUP:
                            MouseHelper.SetClick(MouseEvents.MIDDLEUP, Event.Point.X, Event.Point.Y);
                            break;
                    }
                    if (Event.Key != null)
                    {
                        PressKey(Event.Key);
                    }
                    currentStep = 1;
                    if (!frmMain.Settings.RestartBucle)
                    {
                        frmMain.StopMacro();
                        return;
                    }
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
