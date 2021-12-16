﻿using System;
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
        public bool SettingsMode;

        private SelectedKey key;
        private Settings Settings;
        private System.Timers.Timer _timer;
        private int X;
        private int Y;
        private MacroManager Macro;
        private bool isCaptured;
        private bool isRecording;
        private KeyboardHook keyboardHook;
        private MacroStatus macroStatus;

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
            keyboardHook = new KeyboardHook();
            keyboardHook.KeyDown += new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyDown);
            keyboardHook.Install();

            LoadKeys();
        }

        private void LoadKeys()
        {
            TB_Time.Text = Settings.Seconds.ToString().ToUpper();
            LB_Capture.Text = Settings.Capture.ToString().ToUpper();
            LB_StartBucle.Text = Settings.StartClickBucle.ToString().ToUpper();
            LB_StopBucle.Text = Settings.StopClickBucle.ToString().ToUpper();
            LB_StartMacroRecording.Text = Settings.StartMacroRecording.ToString().ToUpper();
            LB_StopMacroRecording.Text = Settings.StopMacroRecording.ToString().ToUpper();
            LB_PlayRecordedMacro.Text = Settings.PlayRecordedMacro.ToString().ToUpper();
            LB_StopRecordedMacro.Text = Settings.StopRecordedMacro.ToString().ToUpper();
        }

        private void CloseBox_Clicked(object sender, EventArgs e)
        {
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
                    LB_StartMacroRecording.Text = e.KeyData.ToString().ToUpper();
                    Settings.StartMacroRecording = e.KeyData;
                    break;
                case SelectedKey.StopMacroRecording:
                    LB_StopMacroRecording.Text = e.KeyData.ToString().ToUpper();
                    Settings.StopMacroRecording = e.KeyData;
                    break;
                case SelectedKey.PlayRecordedMacro:
                    LB_PlayRecordedMacro.Text = e.KeyData.ToString().ToUpper();
                    Settings.PlayRecordedMacro = e.KeyData;
                    break;
                case SelectedKey.StopRecordedMacro:
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
        private void keyboardHook_KeyDown(KeyboardHook.VKeys key)
        {
            if ((int)key == (int)Settings.Capture)
            {
                if (isRecording) return;

                MouseHelper.GetCursorPos(out POINT p);
                X = p.X;
                Y = p.Y;
                isCaptured = true;
            }
            else if ((int)key == (int)Settings.StartClickBucle)
            {
                if (isRecording) return;
                if (!isCaptured)
                {
                    modCommon.Show("The program dont have loaded any mouse coordenates" + Environment.NewLine + $"Please press \"{Settings.Capture}\" key to capture");
                    return;
                }
                _timer.AutoReset = false;
                _timer.Elapsed += _timer_Elapsed;
                _timer.Start();
            }
            else if ((int)key == (int)Settings.StopClickBucle)
            {
                if (isRecording) return;
                _timer.Stop();
            }
            else if ((int)key == (int)Settings.StartMacroRecording)
            {
                if (isRecording) return;
                isRecording = true;
                Macro.StartRecording();
                WindowState = FormWindowState.Minimized;
                macroStatus = MacroStatus.RecordingMacro;
                LB_MacroStatus.Text = "Recording";
                LB_MacroStatus.ForeColor = Color.DodgerBlue;
            }
            else if ((int)key == (int)Settings.StopMacroRecording)
            {
                isRecording = false;
                if (macroStatus == MacroStatus.RecordingMacro)
                {
                    Macro.StopRecording();
                    WindowState = FormWindowState.Normal;
                    macroStatus = MacroStatus.Stoped;
                    LB_MacroName.Text = "Macro_" + DateTime.Now.Ticks;
                    LB_MacroDuration.Text = $"{modCommon.GetTime(Macro.Duration())}";
                    LB_MacroStatus.Text = "Stoped";
                    LB_MacroStatus.ForeColor = Color.FromArgb(243, 67, 54);
                }
            }
            else if ((int)key == (int)Settings.PlayRecordedMacro)
            {
                if (isRecording) return;
                if (!Macro.HaveRecordedMacro)
                {
                    modCommon.Show("You dont have any recorded macro" + Environment.NewLine + $"Please press \"{Settings.PlayRecordedMacro}\" key to record or load it from file");
                    return;
                }
                Macro.StartMacro();
                WindowState = FormWindowState.Minimized;
                macroStatus = MacroStatus.PlayingMacro;
                LB_MacroStatus.Text = "Running";
                LB_MacroStatus.ForeColor = Color.Lime;
            }
            else if ((int)key == (int)Settings.StopRecordedMacro)
            {
                if (isRecording) return;
                if (macroStatus == MacroStatus.PlayingMacro)
                {
                    Macro.StopMacro();
                    WindowState = FormWindowState.Normal;
                    macroStatus = MacroStatus.Stoped;
                    LB_MacroStatus.Text = "Stoped";
                    LB_MacroStatus.ForeColor = Color.FromArgb(243, 67, 54);
                }
            }
        }
        private enum SelectedKey
        {
            Unknown,
            Capture,
            StartBucle,
            StopBucle,
            StartMacroRecording,
            StopMacroRecording,
            PlayRecordedMacro,
            StopRecordedMacro,
        }
        private enum MacroStatus
        {
            Unknown,
            Stoped,
            RecordingMacro,
            PlayingMacro
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
                        LB_MacroDuration.Text = $"{modCommon.GetTime(Macro.Duration())}";
                        LB_MacroStatus.Text = "Stoped";
                        LB_MacroStatus.ForeColor = Color.FromArgb(243, 67, 54);
                    }
                    else
                    {
                        modCommon.Show("Error loading Macro from file");
                    }
                }
                catch 
                {
                    modCommon.Show("Error loading Macro from file");
                }
            }
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            if (Macro.Record.Count == 0)
            {
                modCommon.Show("The program dont have loaded any macro");
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
    }
}
