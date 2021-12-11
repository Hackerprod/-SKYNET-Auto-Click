using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Capture = Keys.Insert;
                Start = Keys.Home;
                Stop = Keys.End;
            }
        }

        internal void Load()
        {
            
        }

        internal void Save()
        {
            
        }
    }
}
