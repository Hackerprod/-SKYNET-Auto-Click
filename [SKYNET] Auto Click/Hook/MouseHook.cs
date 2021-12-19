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

        public event EventHandler<MouseEvent> OnMouseEvent;

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
            //frmMain.frm.LB_Tittle.Text = ((int)wParam).ToString();
            // parse system messages
            if (nCode >= 0)
            {
                MOUSEINPUT MOUSEINPUT = Marshal.PtrToStructure<MOUSEINPUT>(lParam);
                switch ((IN_MouseMessages)wParam)
                {
                    case IN_MouseMessages.WM_MOUSEMOVE:
                        break;
                    case IN_MouseMessages.WM_MOUSEWHEEL:
                        OnMouseEvent?.Invoke(this, new MouseEvent((MouseMessages)MOUSEINPUT.mouseData, MOUSEINPUT));
                        break;
                    default:
                        OnMouseEvent?.Invoke(this, new MouseEvent((IN_MouseMessages)wParam, MOUSEINPUT));
                        break;
                }
            }
            return CallNextHookEx(hookID, nCode, wParam, lParam);
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

        public class MouseEvent
        {
            public MouseMessages EventType { get; set; }
            public MOUSEINPUT MouseInput { get; set; }

            public MouseEvent(IN_MouseMessages msg, MOUSEINPUT input)
            {
                EventType = ParseType(msg);
                MouseInput = input;
            }
            public MouseEvent(MouseMessages msg, MOUSEINPUT input)
            {
                EventType = msg;
                MouseInput = input;
            }

            private MouseMessages ParseType(IN_MouseMessages msg)
            {
                var values = Enum.GetValues(typeof(MouseMessages));
                foreach (var item in values)
                {
                    if (item.ToString() == msg.ToString())
                    {
                        return (MouseMessages)item;
                    }
                }
                return MouseMessages.None;
            }
        }
    }
    public enum IN_MouseMessages
    {
        WM_LBUTTONDOWN = 513,
        WM_LBUTTONUP = 514,
        WM_MOUSEMOVE = 512,
        WM_MOUSEWHEEL = 522,
        WM_RBUTTONDOWN = 516,
        WM_RBUTTONUP = 517,
        WM_MBUTTONDOWN = 519,
        WM_MBUTTONUP = 520,
        WM_GBUTTONDOWN = 523,
        WM_GBUTTONUP = 524
    }
    public enum MouseMessages
    {
        None = 0,
        ABSOLUTE = 0x8000,

        WM_LBUTTONDOWN = 0x0002,
        WM_LBUTTONUP = 0x0004,
        WM_MOUSEMOVE = 0x0001,
        WM_MOUSEWHEEL = 0x0800,
        WM_MOUSEHWHEEL = 0x01000,
        WM_RBUTTONDOWN = 0x0008,
        WM_RBUTTONUP = 0x0010,
        WM_MBUTTONDOWN = 0x0020,
        WM_MBUTTONUP = 0x0040,
        WM_GBUTTONDOWN = 0x0080,
        WM_GBUTTONUP = 0x0100,

        ScrollUp = 7864320,
        ScrollDown = -7864320,
    }
}
