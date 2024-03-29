﻿using SKYNET;
using SKYNET.GUI;
using System;
using System.Drawing;
using System.Windows.Forms;
using static frmMessage;

public partial class frmMessage : frmBase
{
    private bool mouseDown;     
    private Point lastLocation; 
    public TypeMessage typeMessage;
    public frmMessage(string message, TypeMessage type = TypeMessage.Normal)
    {
        InitializeComponent();
        CheckForIllegalCrossThreadCalls = false;  
        base.EnableShadows = true;
        typeMessage = type;

        switch (typeMessage)
        {
            case TypeMessage.Alert:
                break;
            case TypeMessage.Normal:
                acepctBtn.Visible = false;
                cancelBtn.Text = "Close";
                break;
            case TypeMessage.YesNo:

                break;
        }
        txtMessage.Text = message;
    }
    private void Event_MouseMove(object sender, MouseEventArgs e)
    {
        if (mouseDown)
        {
            Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
            Update();
        }
    }

    private void Event_MouseDown(object sender, MouseEventArgs e)
    {
        mouseDown = true;
        lastLocation = e.Location;
    }

    private void Event_MouseUp(object sender, MouseEventArgs e)
    {
        mouseDown = false;
    }


    private void cancelBtn_Click(object sender, EventArgs e)
    {
        Cancel.PerformClick();
        Close();
    }

    private void acepctBtn_Click(object sender, EventArgs e)
    {
        ok.PerformClick();
    }



    private void frmMessage_Activated(object sender, EventArgs e)
    {
    }

    private void frmMessage_Deactivate(object sender, EventArgs e)
    {
    }

    private void TxtMessage_KeyDown(object sender, KeyEventArgs e)
    {
        e.SuppressKeyPress = true;
    }

    private void TxtMessage_Enter(object sender, EventArgs e)
    {
        textBox1.Focus();
    }
    public enum TypeMessage
    {
        Normal,
        Alert,
        YesNo
    }
}

