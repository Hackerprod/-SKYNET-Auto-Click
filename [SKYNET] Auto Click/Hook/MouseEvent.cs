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
        public MouseMessages Button;
        public KeyPressed Key;

        public MouseEvent(POINT _Point, MouseMessages _Button, KeyPressed _Key)
        {
            Point = _Point;
            Button = _Button;
            Key = _Key;
        }
        public MouseEvent(POINT _Point, MouseMessages _Button)
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
}
