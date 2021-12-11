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
        public Keys Capture { get; set; }
        public Keys Start { get; set; }
        public Keys Stop { get; set; }

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
                Start = Keys.Home;
                Stop = Keys.End;
                Seconds = 5;

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
                    Start   = s.Start;
                    Stop    = s.Stop;
                    Seconds = s.Seconds;
                }
            }
            catch 
            {
                Capture = Keys.Insert;
                Start = Keys.Home;
                Stop = Keys.End;
                Seconds = 5;
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
