using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using GlobalLowLevelHooks;
using SKYNET.GUI;

namespace SKYNET
{
    public partial class frmMain : frmBase
    {
        private KeyboardHook keyboardHook;
        private System.Timers.Timer _timer;
        private int X;
        private int Y;
        public static Settings Settings;

        public frmMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            SetMouseMove(PN_Top);

            _timer = new System.Timers.Timer();
            Settings = new Settings();
            Settings.Load();

            ShowSettings();
        }

        private void ShowSettings()
        {
            LB_Capture.Text = $"Press {Settings.Capture} button to capture mouse location";
            LB_Start.Text = $"Press {Settings.Start} button to start";
            LB_Stop.Text = $"Press {Settings.Stop} button to stop";
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            LeftMouseClick(X, Y);

            _timer.Interval = Settings.Seconds * 1000;
            _timer.Start();
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        //Esto reemplaza a Cursor.Position en WinForms
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        public static bool SettingsMode { get; internal set; }

        //Esto simula un click con el botón izquierdo del ratón
        public static void LeftMouseClick(int xpos, int ypos)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            keyboardHook = new KeyboardHook();
            keyboardHook.KeyDown += new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyDown);
            keyboardHook.Install();
        }

        private void keyboardHook_KeyDown(KeyboardHook.VKeys key)
        {
            if ((int)key == (int)Settings.Capture)
            {
                GetCursorPos(out POINT p);
                X = p.X;
                Y = p.Y;
                LB_CurrentLocation.Text = $"Current location (X:{X} Y:{Y})";
            }
            else if ((int)key == (int)Settings.Start)
            {
                _timer.AutoReset = false;
                _timer.Elapsed += _timer_Elapsed;
                _timer.Start();
            }
            else if ((int)key == (int)Settings.Stop)
            {
                _timer.Stop();
            }
        }

        private void CloseBox_Clicked(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizeBox_Clicked(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BT_Settings_Click(object sender, EventArgs e)
        {
            new frmSettings().ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Save();
        }
    }
}
