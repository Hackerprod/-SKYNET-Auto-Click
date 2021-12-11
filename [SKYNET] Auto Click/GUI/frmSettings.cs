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
    public partial class frmSettings : frmBase
    {
        private Settings settings;
        private SetKey key;
        public frmSettings()
        {
            InitializeComponent();

            settings = frmMain.Settings;
        }


        private void CloseBox_Clicked(object sender, EventArgs e)
        {
            frmMain.SettingsMode = false;
            Close(); 
        }

        private void MinimizeBox_Clicked(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void LB_Capture_Click(object sender, EventArgs e)
        {
            LB_Capture.Text = "Press any key to continue";
            textBox.Focus();
            key = SetKey.Capture;
        }

        private void LB_Start_Click(object sender, EventArgs e)
        {
            LB_Start.Text = "Press any key to continue";
            textBox.Focus();
            key = SetKey.Start;
        }

        private void LB_Stop_Click(object sender, EventArgs e)
        {
            LB_Stop.Text = "Press any key to continue";
            textBox.Focus();
            key = SetKey.Stop;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            TB_Time.Text = frmMain.Settings.Seconds.ToString().ToUpper();
            LB_Capture.Text = frmMain.Settings.Capture.ToString().ToUpper();
            LB_Start.Text = frmMain.Settings.Start.ToString().ToUpper();
            LB_Stop.Text = frmMain.Settings.Stop.ToString().ToUpper();
        }

        private void BT_Apply_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TB_Time.Text, out int seconds))
            {
                settings.Seconds = seconds;
            }
            frmMain.Settings = settings;
            Close();
        }

        private void BT_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (key)
            {
                case SetKey.Capture:
                    {
                        LB_Capture.Text = e.KeyData.ToString().ToUpper();
                        settings.Capture = e.KeyData;
                    }
                    break;
                case SetKey.Start:
                    {
                        LB_Start.Text = e.KeyData.ToString().ToUpper();
                        settings.Start = e.KeyData;
                    }
                    break;
                case SetKey.Stop:
                    {
                        LB_Stop.Text = e.KeyData.ToString().ToUpper();
                        settings.Stop = e.KeyData;
                    }
                    break;
            }
            key = SetKey.Unknown;
            textBox.Text = "";
        }
        private enum SetKey
        {
            Unknown,
            Capture,
            Start,
            Stop
        }

    }
}
