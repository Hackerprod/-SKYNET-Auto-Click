using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SKYNET
{
    /// <summary>
    /// Class for intercepting low level Windows mouse hooks.
    /// </summary>
    public class MouseHook
    {
        private delegate IntPtr MouseHookHandler(int nCode, IntPtr wParam, IntPtr lParam);
        private MouseHookHandler hookHandler;
        private IntPtr hookID = IntPtr.Zero;
        private const int WH_MOUSE_LL = 14;

        public event EventHandler<MSLLHOOKSTRUCT> LeftButtonDown;
        public event EventHandler<MSLLHOOKSTRUCT> LeftButtonUp;
        public event EventHandler<MSLLHOOKSTRUCT> RightButtonDown;
        public event EventHandler<MSLLHOOKSTRUCT> RightButtonUp;
        public event EventHandler<MSLLHOOKSTRUCT> MouseMove;
        public event EventHandler<MSLLHOOKSTRUCT> MouseWheel;
        public event EventHandler<MSLLHOOKSTRUCT> DoubleClick;
        public event EventHandler<MSLLHOOKSTRUCT> MiddleButtonDown;
        public event EventHandler<MSLLHOOKSTRUCT> MiddleButtonUp;
        public event EventHandler<MSLLHOOKSTRUCT> GamerButtonDown;
        public event EventHandler<MSLLHOOKSTRUCT> GamerButtonUp;


        public void Install()
        {
            hookHandler = HookFunc;
            hookID = SetHook(hookHandler);
        }

        public void Uninstall()
        {
            if (hookID == IntPtr.Zero)
                return;

            UnhookWindowsHookEx(hookID);
            hookID = IntPtr.Zero;
        }

        ~MouseHook()
        {
            Uninstall();
        }

        private IntPtr SetHook(MouseHookHandler proc)
        {
            using (ProcessModule module = Process.GetCurrentProcess().MainModule)
                return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(module.ModuleName), 0);
        }

        private IntPtr HookFunc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            // parse system messages
            if (nCode >= 0)
            {
                switch ((MouseMessages)wParam)
                {
                    case MouseMessages.WM_LBUTTONDOWN:
                        LeftButtonDown?.Invoke(this, (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
                        break;
                    case MouseMessages.WM_LBUTTONUP:
                        LeftButtonUp?.Invoke(this, (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
                        break;
                    case MouseMessages.WM_MOUSEMOVE:
                        MouseMove?.Invoke(this, (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
                        break;
                    case MouseMessages.WM_MOUSEWHEEL:
                        MouseWheel?.Invoke(this, (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
                        break;
                    case MouseMessages.WM_RBUTTONDOWN:
                        RightButtonDown?.Invoke(this, (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
                        break;
                    case MouseMessages.WM_RBUTTONUP:
                        RightButtonUp?.Invoke(this, (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
                        break;
                    case MouseMessages.WM_LBUTTONDBLCLK:
                        DoubleClick?.Invoke(this, (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
                        break;
                    case MouseMessages.WM_MBUTTONDOWN:
                        MiddleButtonDown?.Invoke(this, (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
                        break;
                    case MouseMessages.WM_MBUTTONUP:
                        MiddleButtonUp?.Invoke(this, (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
                        break;
                    case MouseMessages.WM_GBUTTONDOWN:
                        GamerButtonDown?.Invoke(this, (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
                        break;
                    case MouseMessages.WM_GBUTTONUP:
                        GamerButtonUp?.Invoke(this, (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
                        break;
                    default:
                        modCommon.Show(wParam);
                        break;
                }

            }
            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }


        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205,
            WM_LBUTTONDBLCLK = 0x0203,
            WM_MBUTTONDOWN = 0x0207,
            WM_MBUTTONUP = 0x0208,
            WM_GBUTTONDOWN = 523,
            WM_GBUTTONUP = 524
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, MouseHookHandler lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
