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
            NativeMethods.mouse_event((int)Event, x, y, 0, 0);
        }
        public static void SetDoubleClick(int x, int y)
        {
            int LEFTDOWN = 0x02;
            int LEFTUP = 0x04;
            NativeMethods.mouse_event(LEFTDOWN | LEFTUP, x, y, 0, 0);
            Thread.Sleep(150);
            NativeMethods.mouse_event(LEFTDOWN | LEFTUP, x, y, 0, 0);

        }

        public static void LeftClick(int x, int y, bool move = false)
        {
            if (move)
            {
                NativeMethods.SetCursorPos(x, y);
            }

            NativeMethods.mouse_event((int)MouseMessages.WM_LBUTTONDOWN, x, y, 0, 0);
            Thread.Sleep(29);
            NativeMethods.mouse_event((int)MouseMessages.WM_LBUTTONUP, x, y, 0, 0);
        }

        public static void RightClick(int x, int y, bool move = false)
        {
            if (move)
            {
                NativeMethods.SetCursorPos(x, y);
            }

            NativeMethods.mouse_event((int)MouseMessages.WM_RBUTTONDOWN, x, y, 0, 0);
            Thread.Sleep(29);
            NativeMethods.mouse_event((int)MouseMessages.WM_RBUTTONUP, x, y, 0, 0);
        }

        internal static void SetWheel(MouseMessages wheel, int x, int y)
        {
            if (wheel == MouseMessages.ScrollUp)
            {
                NativeMethods.mouse_event((int)MouseMessages.WM_MOUSEWHEEL, x, y, 120, 0);
            }
            else if (wheel == MouseMessages.ScrollDown)
            {
                NativeMethods.mouse_event((int)MouseMessages.WM_MOUSEWHEEL, x, y, -120, 0);
            }
        }

        internal static void SetXClick(MouseMessages button, int x, int y)
        {
            MouseMessages flags = 0;
            int xbutton = 0;
            switch (button)
            {
                case MouseMessages.XButton1Up:
                    flags = MouseMessages.WM_XBUTTONUP;
                    xbutton = 0x00000001;
                    break;
                case MouseMessages.XButton1Down:
                    flags = MouseMessages.WM_XBUTTONDOWN;
                    xbutton = 0x00000001;
                    break;
                case MouseMessages.XButton2Up:
                    flags = MouseMessages.WM_XBUTTONUP;
                    xbutton = 0x00000002;
                    break;
                case MouseMessages.XButton2Down:
                    flags = MouseMessages.WM_XBUTTONDOWN;
                    xbutton = 0x00000002;
                    break;
                default:
                    break;
            }
            NativeMethods.mouse_event((int)flags, x, y, xbutton, 0);
        }
        private enum MouseXButton
        {
            XBUTTON1 = 0x00000001,
            XBUTTON2 = 0x00000002,
        }
    }
    public delegate IntPtr MouseHookHandler(int nCode, IntPtr wParam, IntPtr lParam);
}
