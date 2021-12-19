using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace SKYNET.Hook
{
    public class MouseHelper
    {

        public static void SetClick(MouseMessages Event, int x, int y)
        {
            User32.mouse_event((int)Event, x, y, 0, 0);
        }
        public static void SetDoubleClick(int x, int y)
        {
            //modCommon.Show("double");
            int LEFTDOWN = 0x02;
            int LEFTUP = 0x04;
            User32.mouse_event(LEFTDOWN | LEFTUP, x, y, 0, 0);
            Thread.Sleep(150);
            User32.mouse_event(LEFTDOWN | LEFTUP, x, y, 0, 0);

        }

        public static void LeftClick(int x, int y, bool move = false)
        {
            if (move)
            {
                User32.SetCursorPos(x, y);
            }

            User32.mouse_event((int)MouseMessages.WM_LBUTTONDOWN, x, y, 0, 0);
            Thread.Sleep(29);
            User32.mouse_event((int)MouseMessages.WM_LBUTTONUP, x, y, 0, 0);
        }

        public static void RightClick(int x, int y, bool move = false)
        {
            if (move)
            {
                User32.SetCursorPos(x, y);
            }

            User32.mouse_event((int)MouseMessages.WM_RBUTTONDOWN, x, y, 0, 0);
            Thread.Sleep(29);
            User32.mouse_event((int)MouseMessages.WM_RBUTTONUP, x, y, 0, 0);
        }

        internal static void SetWheel(MouseMessages wheel, int x, int y)
        {
            if (wheel == MouseMessages.ScrollUp)
            {
                User32.mouse_event((int)MouseMessages.WM_MOUSEWHEEL, x, y, 120, 0);
            }
            else if (wheel == MouseMessages.ScrollDown)
            {
                User32.mouse_event((int)MouseMessages.WM_MOUSEWHEEL, x, y, -120, 0);
            }
        }
    }
    public delegate IntPtr MouseHookHandler(int nCode, IntPtr wParam, IntPtr lParam);
}
