using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET.Hook
{
    public class MouseEvent
    {
        public POINT Point;
        public MouseEvents Button;
        public KeyPressed Key;

        public MouseEvent(POINT _Point, MouseEvents _Button, KeyPressed _Key)
        {
            Point = _Point;
            Button = _Button;
            Key = _Key;
        }
        public MouseEvent(POINT _Point, MouseEvents _Button)
        {
            Point = _Point;
            Button = _Button;
        }
        public MouseEvent()
        {

        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;

        public static implicit operator Point(POINT point)
        {
            return new Point(point.X, point.Y);
        }
    }
    public enum MouseEvents
    {
        None = 0,
        ABSOLUTE = 0x8000,
        LEFTDOWN = 0x0002,
        LEFTUP = 0x0004,
        MIDDLEDOWN = 0x0020,
        MIDDLEUP = 0x0040,
        MOVE = 0x0001,
        RIGHTDOWN = 0x0008,
        RIGHTUP = 0x0010,
        XDOWN = 0x0080,
        XUP = 0x0100,
        WHEEL = 0x0800,
        HWHEEL = 0x01000
    }
}
