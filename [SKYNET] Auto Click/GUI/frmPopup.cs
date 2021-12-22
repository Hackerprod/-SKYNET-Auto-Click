using SKYNET;
using SKYNET.GUI;
using System;
using System.Drawing;
using System.Windows.Forms;
using static frmMessage;

public partial class frmPopup : frmBase
{
    public PopupType Type;
    public frmPopup(PopupType type)
    {
        InitializeComponent();

        Type = type;

        switch (Type)
        {
            case PopupType.Recording:
                LB_Action.Text = "RECORDING";
                LB_Action.ForeColor = Color.DodgerBlue;
                break;
            case PopupType.Playing:
                LB_Action.Text = "PLAYING";
                LB_Action.ForeColor = Color.Lime;
                break;
            default:
                break;
        }

        int yy = 0;
        Rectangle rScreen;
        try
        {
            rScreen = Screen.GetWorkingArea(Screen.PrimaryScreen.Bounds);
            yy = checked(rScreen.Height - this.Height - yy);
            NativeMethods.SetWindowPos(this.Handle, -1, checked(rScreen.Width - this.Width), yy, this.Width, this.Height, 16U);
        }
        catch (Exception ex)
        {
        }
    }

    public enum PopupType
    {
        Recording,
        Playing
    }

    private void Mouse_Move(object sender, MouseEventArgs e)
    {
        Opacity = 0.87;
    }

    private void Mouse_Leave(object sender, EventArgs e)
    {
        Opacity = 100;
    }

    private void frmPopup_Load(object sender, EventArgs e)
    {

    }

    internal void SetTime(string time)
    {
        LB_Time.Text = time;
    }
}

