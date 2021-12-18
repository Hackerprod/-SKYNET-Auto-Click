using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using SKYNET.Hook;

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

        public event EventHandler<MOUSEINPUT> LeftButtonDown;
        public event EventHandler<MOUSEINPUT> LeftButtonUp;
        public event EventHandler<MOUSEINPUT> RightButtonDown;
        public event EventHandler<MOUSEINPUT> RightButtonUp;
        public event EventHandler<MOUSEINPUT> MouseMove;
        public event EventHandler<MOUSEINPUT> MouseWheel;
        public event EventHandler<MOUSEINPUT> DoubleClick;
        public event EventHandler<MOUSEINPUT> MiddleButtonDown;
        public event EventHandler<MOUSEINPUT> MiddleButtonUp;
        public event EventHandler<MOUSEINPUT> GamerButtonDown;
        public event EventHandler<MOUSEINPUT> GamerButtonUp;


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
                MOUSEINPUT MOUSEINPUT = Marshal.PtrToStructure<MOUSEINPUT>(lParam);
                frmMain.frm.LB_Tittle.Text = MOUSEINPUT.dwFlags.ToString();

                switch ((MouseMessages)wParam)
                {
                    case MouseMessages.WM_LBUTTONDOWN:
                        LeftButtonDown?.Invoke(this, MOUSEINPUT);
                        break;
                    case MouseMessages.WM_LBUTTONUP:
                        LeftButtonUp?.Invoke(this, MOUSEINPUT);
                        break;
                    case MouseMessages.WM_MOUSEMOVE:
                        MouseMove?.Invoke(this, MOUSEINPUT);
                        break;
                    case MouseMessages.WM_MOUSEWHEEL:
                        MouseWheel?.Invoke(this, MOUSEINPUT);
                        break;
                    case MouseMessages.WM_RBUTTONDOWN:
                        RightButtonDown?.Invoke(this, MOUSEINPUT);
                        break;
                    case MouseMessages.WM_RBUTTONUP:
                        RightButtonUp?.Invoke(this, MOUSEINPUT);
                        break;
                    case MouseMessages.WM_LBUTTONDBLCLK:
                        DoubleClick?.Invoke(this, MOUSEINPUT);
                        break;
                    case MouseMessages.WM_MBUTTONDOWN:
                        MiddleButtonDown?.Invoke(this, MOUSEINPUT);
                        break;
                    case MouseMessages.WM_MBUTTONUP:
                        MiddleButtonUp?.Invoke(this, MOUSEINPUT);
                        break;
                    case MouseMessages.WM_GBUTTONDOWN:
                        GamerButtonDown?.Invoke(this, MOUSEINPUT);
                        break;
                    case MouseMessages.WM_GBUTTONUP:
                        GamerButtonUp?.Invoke(this, MOUSEINPUT);
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

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, MouseHookHandler lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [Flags]
        public enum MOUSEEVENTF : uint
        {
            MOUSEEVENTF_ABSOLUTE = 0x8000,
            MOUSEEVENTF_HWHEEL = 0x01000,
            MOUSEEVENTF_MOVE = 0x0001,
            MOUSEEVENTF_MOVE_NOCOALESCE = 0x2000,
            MOUSEEVENTF_LEFTDOWN = 0x0002,
            MOUSEEVENTF_LEFTUP = 0x0004,
            MOUSEEVENTF_RIGHTDOWN = 0x0008,
            MOUSEEVENTF_RIGHTUP = 0x0010,
            MOUSEEVENTF_MIDDLEDOWN = 0x0020,
            MOUSEEVENTF_MIDDLEUP = 0x0040,
            MOUSEEVENTF_VIRTUALDESK = 0x4000,
            MOUSEEVENTF_WHEEL = 0x0800,
            MOUSEEVENTF_XDOWN = 0x0080,
            MOUSEEVENTF_XUP = 0x0100,
        }
    }
}
