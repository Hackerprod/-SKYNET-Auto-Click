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
using SKYNET.GUI;
using SKYNET.Hook;

namespace SKYNET
{
    public partial class frmMain : frmBase
    {
        private KeyboardHook keyboardHook;
        private System.Timers.Timer _timer;
        private int X;
        private int Y;
        public static Settings Settings;
        public static bool SettingsMode;


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
            LB_Capture.Text = $"Press {Settings.Capture.ToString().ToUpper()} button to capture mouse location";
            LB_Start.Text = $"Press {Settings.Start.ToString().ToUpper()} button to start";
            LB_Stop.Text = $"Press {Settings.Stop.ToString().ToUpper()} button to stop";
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MouseHook.LeftMouseClick(X, Y);

            _timer.Interval = Settings.Seconds * 1000;
            _timer.Start();
        }        

        private void frmMain_Load(object sender, EventArgs e)
        {
            keyboardHook = new KeyboardHook();
            keyboardHook.KeyDown += new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyDown);
            keyboardHook.Install();
        }

        private void keyboardHook_KeyDown(KeyboardHook.VKeys key)
        {
            if (SettingsMode) return;

            if ((int)key == (int)Settings.Capture)
            {
                MouseHook.GetCursorPos(out MouseHook.POINT p);
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
            SettingsMode = true;
            Visible = false;
            new frmSettings().ShowDialog();
            SettingsMode = false;
            Visible = true;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Save();
        }
    }
}
