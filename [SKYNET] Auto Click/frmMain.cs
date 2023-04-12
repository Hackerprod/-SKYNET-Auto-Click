using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using SKYNET.GUI;
using SKYNET.Hook;

namespace SKYNET
{
    public partial class frmMain : frmBase
    {
        public static frmMain frm;
        public static Settings Settings;
        public static frmPopup Popup;

        public bool SettingsMode;

        private SelectedKey key;
        private System.Timers.Timer _timer;
        private int X;
        private int Y;
        private MacroManager Macro;
        private bool isCaptured;
        private bool isRecording;
        private MacroStatus macroStatus;
        private const int WM_HOTKEY = 0x0312;

        public frmMain()
        {
            InitializeComponent();
            base.SetMouseMove(PN_Top);
            frm = this;

            _timer = new System.Timers.Timer();

            Settings = new Settings();
            Settings.Load();

            Macro = new MacroManager();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            LoadKeys();

            NativeMethods.RegisterHotKey(this.Handle, (int)Settings.Capture, 0, (int)Settings.Capture);
            NativeMethods.RegisterHotKey(this.Handle, (int)Settings.StartClickBucle, 0, (int)Settings.StartClickBucle);
            NativeMethods.RegisterHotKey(this.Handle, (int)Settings.StopClickBucle, 0, (int)Settings.StopClickBucle);
            NativeMethods.RegisterHotKey(this.Handle, (int)Settings.StartMacroRecording, 0, (int)Settings.StartMacroRecording);
            NativeMethods.RegisterHotKey(this.Handle, (int)Settings.StopMacroRecording, 0, (int)Settings.StopMacroRecording);
            NativeMethods.RegisterHotKey(this.Handle, (int)Settings.PlayRecordedMacro, 0, (int)Settings.PlayRecordedMacro);
            NativeMethods.RegisterHotKey(this.Handle, (int)Settings.StopRecordedMacro, 0, (int)Settings.StopRecordedMacro);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                Keys Pressed = (Keys)m.WParam.ToInt32();

                if (Pressed == Settings.Capture)
                {
                    if (isRecording) return;
                    NativeMethods.GetCursorPos(out POINT p);
                    X = p.X;
                    Y = p.Y;
                    isCaptured = true;
                }
                else if (Pressed == Settings.StartClickBucle)
                {
                    if (isRecording) return;
                    if (!isCaptured)
                    {
                        Common.Show("The program dont have loaded any mouse coordenates" + Environment.NewLine + $"Please press \"{Settings.Capture}\" key to capture");
                        return;
                    }
                    _timer.AutoReset = false;
                    _timer.Elapsed += _timer_Elapsed;
                    _timer.Start();
                }
                else if (Pressed == Settings.StopClickBucle)
                {
                    if (isRecording) return;
                    _timer.Stop();
                }
                else if (Pressed == Settings.StartMacroRecording)
                {
                    if (isRecording) return;
                    isRecording = true;
                    Macro.StartRecording();
                    macroStatus = MacroStatus.RecordingMacro;
                    LB_MacroStatus.Text = "Recording";
                    LB_MacroStatus.ForeColor = Color.DodgerBlue;
                    if (Settings.MinimizeWhenStarts) WindowState = FormWindowState.Minimized;
                    if (Settings.ShowPopup) (Popup = new frmPopup(frmPopup.PopupType.Recording)).Show();
                }
                else if (Pressed == Settings.StopMacroRecording)
                {
                    isRecording = false;
                    if (macroStatus == MacroStatus.RecordingMacro)
                    {
                        Macro.StopRecording();
                        macroStatus = MacroStatus.Stoped;
                        LB_MacroName.Text = "Macro_" + DateTime.Now.Ticks;
                        LB_MacroDuration.Text = $"{Common.GetTime(Macro.Duration())}";
                        LB_MacroStatus.Text = "Stoped";
                        LB_MacroStatus.ForeColor = Color.FromArgb(243, 67, 54);
                        if (Settings.MinimizeWhenStarts) WindowState = FormWindowState.Normal;
                        if (Popup != null) Popup.Close();
                    }
                }
                else if (Pressed == Settings.PlayRecordedMacro)
                {
                    if (isRecording) return;
                    if (!Macro.HaveRecordedMacro)
                    {
                        Common.Show("You dont have any recorded macro" + Environment.NewLine + $"Please press \"{Settings.PlayRecordedMacro}\" key to record or load it from file");
                        return;
                    }
                    Macro.StartMacro(Settings.MacroInterval);
                    macroStatus = MacroStatus.PlayingMacro;
                    LB_MacroStatus.Text = "Running";
                    LB_MacroStatus.ForeColor = Color.Lime;
                    if (Settings.MinimizeWhenStarts) WindowState = FormWindowState.Minimized;
                    if (Settings.ShowPopup) (Popup = new frmPopup(frmPopup.PopupType.Playing)).Show();
                }
                else if (Pressed == Settings.StopRecordedMacro)
                {
                    if (isRecording) return;
                    if (macroStatus == MacroStatus.PlayingMacro)
                    {
                        StopMacro();
                    }
                    if (Popup != null) Popup.Close();
                }
            }
            else

            base.WndProc(ref m);
        }

        public static void StopMacro()
        {
            frm.Macro.StopMacro();
            frm.macroStatus = MacroStatus.Stoped;
            frm.LB_MacroStatus.Text = "Stoped";
            frm.LB_MacroStatus.ForeColor = Color.FromArgb(243, 67, 54);
            if (Settings.MinimizeWhenStarts) frm.WindowState = FormWindowState.Normal;
        }

        private void LoadKeys()
        {
            TB_Time.Text = Settings.Seconds.ToString().ToUpper();
            TB_MacroInterval.Text = Settings.MacroInterval.ToString().ToUpper();
            LB_Capture.Text = Settings.Capture.ToString().ToUpper();
            LB_StartBucle.Text = Settings.StartClickBucle.ToString().ToUpper();
            LB_StopBucle.Text = Settings.StopClickBucle.ToString().ToUpper();
            LB_StartMacroRecording.Text = Settings.StartMacroRecording.ToString().ToUpper();
            LB_StopMacroRecording.Text = Settings.StopMacroRecording.ToString().ToUpper();
            LB_PlayRecordedMacro.Text = Settings.PlayRecordedMacro.ToString().ToUpper();
            LB_StopRecordedMacro.Text = Settings.StopRecordedMacro.ToString().ToUpper();
            CH_RestartBucle.Checked = Settings.RestartBucle;
            CH_MinimizeWhenStarts.Checked = Settings.MinimizeWhenStarts;
            CH_ShowPopup.Checked = Settings.ShowPopup;
        }

        private void CloseBox_Clicked(object sender, EventArgs e)
        {
            NativeMethods.UnregisterHotKey(this.Handle, (int)Settings.Capture);
            NativeMethods.UnregisterHotKey(this.Handle, (int)Settings.StartClickBucle);
            NativeMethods.UnregisterHotKey(this.Handle, (int)Settings.StopClickBucle);
            NativeMethods.UnregisterHotKey(this.Handle, (int)Settings.StartMacroRecording);
            NativeMethods.UnregisterHotKey(this.Handle, (int)Settings.StopMacroRecording);
            NativeMethods.UnregisterHotKey(this.Handle, (int)Settings.PlayRecordedMacro);
            NativeMethods.UnregisterHotKey(this.Handle, (int)Settings.StopRecordedMacro);
            Application.Exit(); 
        }

        private void MinimizeBox_Clicked(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #region Buttons Click Event

        private void Capture_Click(object sender, EventArgs e)
        {
            LoadKeys();
            LB_Capture.Text = "Press any key to continue";
            textBox.Focus();
            key = SelectedKey.Capture;
        }

        private void StartBucle_Click(object sender, EventArgs e)
        {
            LoadKeys();
            LB_StartBucle.Text = "Press any key to continue";
            textBox.Focus();
            key = SelectedKey.StartBucle;
        }

        private void StopBucle_Click(object sender, EventArgs e)
        {
            LoadKeys();
            LB_StopBucle.Text = "Press any key to continue";
            textBox.Focus();
            key = SelectedKey.StopBucle;
        }

        private void StartMacroRecording_Click(object sender, EventArgs e)
        {
            LoadKeys();
            LB_StartMacroRecording.Text = "Press any key to continue";
            textBox.Focus();
            key = SelectedKey.StartMacroRecording;
        }

        private void StopMacroRecording_Click(object sender, EventArgs e)
        {
            LoadKeys();
            LB_StopMacroRecording.Text = "Press any key to continue";
            textBox.Focus();
            key = SelectedKey.StopMacroRecording;
        }

        private void PlayRecordedMacro_Click(object sender, EventArgs e)
        {
            LoadKeys();
            LB_PlayRecordedMacro.Text = "Press any key to continue";
            textBox.Focus();
            key = SelectedKey.PlayRecordedMacro;
        }

        private void StopRecordedMacro_Click(object sender, EventArgs e)
        {
            LoadKeys();
            LB_StopRecordedMacro.Text = "Press any key to continue";
            textBox.Focus();
            key = SelectedKey.StopRecordedMacro;
        }

        #endregion

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (key)
            {
                case SelectedKey.Unknown:
                    break;
                case SelectedKey.Capture:
                    LB_Capture.Text = e.KeyData.ToString().ToUpper();
                    Settings.Capture = e.KeyData;
                    break;
                case SelectedKey.StartBucle:
                    LB_StartBucle.Text = e.KeyData.ToString().ToUpper();
                    Settings.StartClickBucle = e.KeyData;
                    break;
                case SelectedKey.StopBucle:
                    LB_StopBucle.Text = e.KeyData.ToString().ToUpper();
                    Settings.StopClickBucle = e.KeyData;
                    break;
                case SelectedKey.StartMacroRecording:
                    if (Settings.MinimizeWhenStarts) WindowState = FormWindowState.Minimized;
                    LB_StartMacroRecording.Text = e.KeyData.ToString().ToUpper();
                    Settings.StartMacroRecording = e.KeyData;
                    break;
                case SelectedKey.StopMacroRecording:
                    if (Settings.MinimizeWhenStarts) WindowState = FormWindowState.Normal;
                    LB_StopMacroRecording.Text = e.KeyData.ToString().ToUpper();
                    Settings.StopMacroRecording = e.KeyData;
                    break;
                case SelectedKey.PlayRecordedMacro:
                    if (Settings.MinimizeWhenStarts) WindowState = FormWindowState.Minimized;
                    LB_PlayRecordedMacro.Text = e.KeyData.ToString().ToUpper();
                    Settings.PlayRecordedMacro = e.KeyData;
                    break;
                case SelectedKey.StopRecordedMacro:
                    if (Settings.MinimizeWhenStarts) WindowState = FormWindowState.Normal;
                    LB_StopRecordedMacro.Text = e.KeyData.ToString().ToUpper();
                    Settings.StopRecordedMacro = e.KeyData;
                    break;
            }
            key = SelectedKey.Unknown;
            textBox.Text = "";
            Settings.Save();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MouseHelper.LeftClick(X, Y, true);

            _timer.Interval = Settings.Seconds * 1000;
            _timer.Start();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog()
            {
                Title = "Select macro file",
                Filter = "Macro file | *.macro",
                Multiselect = false,
            };
            var dialogResult = openDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    string JSON = File.ReadAllText(openDialog.FileName);
                    var events = new JavaScriptSerializer().Deserialize<List<MouseEvent>>(JSON);
                    if (events != null)
                    {
                        Macro.Record.Clear();
                        for (int i = 0; i < events.Count; i++)
                        {
                            Macro.Record.Add(i + 1, events[i]);
                        }
                        Macro.Step = events.Count + 1;
                        LB_MacroName.Text = Path.GetFileNameWithoutExtension(openDialog.FileName);
                        LB_MacroDuration.Text = $"{Common.GetTime(Macro.Duration())}";
                        LB_MacroStatus.Text = "Stoped";
                        LB_MacroStatus.ForeColor = Color.FromArgb(243, 67, 54);
                    }
                    else
                    {
                        Common.Show("Error loading Macro from file");
                    }
                }
                catch 
                {
                    Common.Show("Error loading Macro from file");
                }
            }
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            if (Macro.Record.Count == 0)
            {
                Common.Show("The program dont have loaded any macro");
                return;
            }

            SaveFileDialog openDialog = new SaveFileDialog()
            {
                Filter = "Macro file | *.macro",
                FileName = LB_MacroName.Text,
                DefaultExt = ".macro"
            };
            var dialogResult = openDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var events = new List<MouseEvent>();
                for (int i = 0; i < Macro.Record.Count; i++)
                {
                    events.Add(Macro.Record[i + 1]);
                }
                string JSON = new JavaScriptSerializer().Serialize(events);
                File.WriteAllText(openDialog.FileName, JSON);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Save();
        }

        private void Time_KeyUp(object sender, KeyEventArgs e)
        {
            if (int.TryParse(TB_Time.Text, out int time))
            {
                Settings.Seconds = time;
                Settings.Save();
            }
        }

        private void MacroInterval_KeyUp(object sender, KeyEventArgs e)
        {
            if (int.TryParse(TB_MacroInterval.Text, out int time))
            {
                Settings.MacroInterval = time;
                Settings.Save();
            }
        }

        private void MinimizeWhenStarts_CheckedChanged(object sender, bool e)
        {
            Settings.MinimizeWhenStarts = CH_MinimizeWhenStarts.Checked;
            Settings.Save();
        }

        private void RestartBucle_CheckedChanged(object sender, bool e)
        {
            Settings.RestartBucle = CH_RestartBucle.Checked;
            Settings.Save();
        }

        private void ShowPopup_CheckedChanged(object sender, bool e)
        {
            Settings.ShowPopup = CH_ShowPopup.Checked;
            Settings.Save();
        }
    }
}
