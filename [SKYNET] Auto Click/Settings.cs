using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SKYNET
{
    public class Settings
    {
        public int Seconds { get; set; }
        public bool MinimizeWhenStarts { get; set; }
        public bool RestartBucle { get; set; }
        public Keys Capture { get; set; }
        public Keys StartClickBucle { get; set; }
        public Keys StopClickBucle { get; set; }
        public Keys StartMacroRecording { get; set; }
        public Keys StopMacroRecording { get; set; }
        public Keys PlayRecordedMacro { get; set; }
        public Keys StopRecordedMacro { get; set; }
        public bool ShowPopup { get; set; }


        ///////////////////////////////////////////////////////////////////

        private RegistryKey Registry { get; set; }

        private string SubKey = @"SOFTWARE\SKYNET\[SKYNET] Auto Click\";

        public Settings()
        {
            Registry = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(SubKey, true);
            if (Registry == null)
            {
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey(SubKey);

                Capture = Keys.Insert;
                StartClickBucle = Keys.Home;
                StopClickBucle = Keys.End;
                Seconds = 5;
                StartMacroRecording = Keys.F1;
                StopMacroRecording = Keys.F2;
                PlayRecordedMacro = Keys.F3;
                StopRecordedMacro = Keys.F4;

                Save();
            }
        }


        public void Load()
        {
            try
            {
                if (Registry != null)
                {
                    string JSON = Registry.GetValue("ParsedSettings", RegistryValueKind.String).ToString();

                    Settings  s = new JavaScriptSerializer().Deserialize<Settings>(JSON);
                    Capture = s.Capture;
                    StartClickBucle   = s.StartClickBucle;
                    StopClickBucle    = s.StopClickBucle;
                    Seconds = s.Seconds;
                    StartMacroRecording = s.StartMacroRecording;
                    StopMacroRecording = s.StopMacroRecording;
                    PlayRecordedMacro = s.PlayRecordedMacro;
                    StopRecordedMacro = s.StopRecordedMacro;
                    MinimizeWhenStarts = s.MinimizeWhenStarts;
                    RestartBucle = s.RestartBucle;
                }
            }
            catch 
            {
                Capture = Keys.Insert;
                StartClickBucle = Keys.Home;
                StopClickBucle = Keys.End;
                Seconds = 5;
                StartMacroRecording = Keys.F1;
                StopMacroRecording = Keys.F2;
                PlayRecordedMacro = Keys.F3;
                StopRecordedMacro = Keys.F4;
            }
        }

        public void Save()
        {
            Registry = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(SubKey, true);
            string JSON = new JavaScriptSerializer().Serialize(this);
            try 
            { 
                Registry.SetValue("ParsedSettings", JSON); 
            } 
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message); 
            }
        }
    }
}
