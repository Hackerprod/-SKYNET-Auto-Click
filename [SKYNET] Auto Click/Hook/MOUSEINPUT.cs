using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.Hook
{
    public unsafe partial struct MOUSEINPUT
    {
        /// <summary>
        /// The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the dwFlags member. Absolute data is specified as the x coordinate of the mouse; relative data is specified as the number of pixels moved.
        /// </summary>
        public int dx;

        /// <summary>
        /// The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the dwFlags member. Absolute data is specified as the y coordinate of the mouse; relative data is specified as the number of pixels moved.
        /// </summary>
        public int dy;

        /// <summary>
        /// If dwFlags contains <see cref="MOUSEEVENTF.MOUSEEVENTF_WHEEL"/>, then <see cref="mouseData"/> specifies the amount of wheel movement. A positive value indicates that the wheel was rotated forward, away from the user; a negative value indicates that the wheel was rotated backward, toward the user. One wheel click is defined as <see cref="WHEEL_DELTA"/>, which is 120.
        /// If dwFlags does not contain <see cref="MOUSEEVENTF.MOUSEEVENTF_WHEEL"/>, <see cref="MOUSEEVENTF.MOUSEEVENTF_XDOWN"/>, or <see cref="MOUSEEVENTF.MOUSEEVENTF_XUP"/>, then mouseData should be zero.
        /// If dwFlags contains <see cref="MOUSEEVENTF.MOUSEEVENTF_XDOWN"/> or <see cref="MOUSEEVENTF.MOUSEEVENTF_XUP"/>, then mouseData specifies which X buttons were pressed or released.
        /// </summary>
        public uint mouseData;

        /// <summary>
        /// A set of bit flags that specify various aspects of mouse motion and button clicks. The bits in this member can be any reasonable combination of the following values.
        /// See MSDN docs for more info.
        /// </summary>
        public MOUSEEVENTF dwFlags;

        /// <summary>
        /// The time stamp for the event, in milliseconds. If this parameter is 0, the system will provide its own time stamp.
        /// </summary>
        public uint time;

        /// <summary>
        /// An additional value associated with the mouse event. An application calls GetMessageExtraInfo to obtain this extra information.
        /// </summary>
        public void* dwExtraInfo;
    }
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
