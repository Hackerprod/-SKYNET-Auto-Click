using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace SKYNET.Hook
{
    public class MouseHelper
    {
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        //Esto reemplaza a Cursor.Position en WinForms
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public static void SetClick(MouseEvents Event, int x, int y)
        {
            mouse_event((int)Event, x, y, 0, 0);
        }
        public static void SetDoubleClick(int x, int y)
        {
            //modCommon.Show("double");
            int LEFTDOWN = 0x02;
            int LEFTUP = 0x04;
            mouse_event(LEFTDOWN | LEFTUP, x, y, 0, 0);
            Thread.Sleep(150);
            mouse_event(LEFTDOWN | LEFTUP, x, y, 0, 0);

        }

        public static void LeftClick(int x, int y, bool move = false)
        {
            if (move)
            {
                SetCursorPos(x, y);
            }

            mouse_event((int)MouseEvents.LeftDown, x, y, 0, 0);
            Thread.Sleep(29);
            mouse_event((int)MouseEvents.LeftUp, x, y, 0, 0);
        }

        public static void RightClick(int x, int y, bool move = false)
        {
            if (move)
            {
                SetCursorPos(x, y);
            }

            mouse_event((int)MouseEvents.RightDown, x, y, 0, 0);
            Thread.Sleep(29);
            mouse_event((int)MouseEvents.RightUp, x, y, 0, 0);
        }

    }
}
