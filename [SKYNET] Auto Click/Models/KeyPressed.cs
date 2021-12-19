using System.Windows.Forms;

namespace SKYNET
{
    public class KeyPressed
    {
        public Keys Key;
        public KeyAction Action;

        public KeyPressed(Keys key, KeyAction action)
        {
            Key = key;
            Action = action;
        }
        public KeyPressed()
        {
        }
    }
    public enum KeyAction
    {
        KeyDown = 0x1,
        KeyUp = 0x2
    }
}