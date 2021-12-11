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
    public partial class frmSettings : frmBase
    {
        private KeyboardHook keyboardHook;
        public frmSettings()
        {
            InitializeComponent();
            frmMain.SettingsMode = true;
        }


        private void CloseBox_Clicked(object sender, EventArgs e)
        {
            frmMain.SettingsMode = false;
            Close(); ;
        }

        private void MinimizeBox_Clicked(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
