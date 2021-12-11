
namespace SKYNET
{
    partial class frmSettings
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.MinimizeBox = new SKYNET.Controls.SKYNET_MinimizeBox();
            this.CloseBox = new SKYNET.Controls.SKYNET_CloseBox();
            this.skyneT_Button1 = new SKYNET.Controls.SKYNET_Button();
            this.LB_Tittle = new SKYNET.Controls.SKYNET_Label();
            this.skyneT_Label1 = new SKYNET.Controls.SKYNET_Label();
            this.skyneT_Label2 = new SKYNET.Controls.SKYNET_Label();
            this.skyneT_Label3 = new SKYNET.Controls.SKYNET_Label();
            this.LB_Capture = new SKYNET.Controls.SKYNET_Label();
            this.LB_CurrentLocation = new SKYNET.Controls.SKYNET_Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MinimizeBox);
            this.panel1.Controls.Add(this.CloseBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 25);
            this.panel1.TabIndex = 2;
            // 
            // MinimizeBox
            // 
            this.MinimizeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.MinimizeBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.MinimizeBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinimizeBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.MinimizeBox.Location = new System.Drawing.Point(325, 0);
            this.MinimizeBox.MaximumSize = new System.Drawing.Size(34, 26);
            this.MinimizeBox.MinimumSize = new System.Drawing.Size(34, 26);
            this.MinimizeBox.Name = "MinimizeBox";
            this.MinimizeBox.Size = new System.Drawing.Size(34, 26);
            this.MinimizeBox.TabIndex = 4;
            this.MinimizeBox.Clicked += new System.EventHandler(this.MinimizeBox_Clicked);
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.CloseBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.CloseBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.CloseBox.Location = new System.Drawing.Point(359, 0);
            this.CloseBox.MaximumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.MinimumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(34, 26);
            this.CloseBox.TabIndex = 4;
            this.CloseBox.Clicked += new System.EventHandler(this.CloseBox_Clicked);
            // 
            // skyneT_Button1
            // 
            this.skyneT_Button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.skyneT_Button1.BackColorMouseOver = System.Drawing.Color.Empty;
            this.skyneT_Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.skyneT_Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.skyneT_Button1.ForeColor = System.Drawing.Color.White;
            this.skyneT_Button1.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.skyneT_Button1.ImageAlignment = SKYNET.Controls.SKYNET_Button.ImgAlign.Left;
            this.skyneT_Button1.ImageIcon = null;
            this.skyneT_Button1.Location = new System.Drawing.Point(339, 204);
            this.skyneT_Button1.MenuMode = true;
            this.skyneT_Button1.Name = "skyneT_Button1";
            this.skyneT_Button1.Rounded = false;
            this.skyneT_Button1.Size = new System.Drawing.Size(42, 28);
            this.skyneT_Button1.Style = SKYNET.Controls.SKYNET_Button._Style.TextOnly;
            this.skyneT_Button1.TabIndex = 3;
            this.skyneT_Button1.Text = "Settings";
            // 
            // LB_Tittle
            // 
            this.LB_Tittle.ChangeColor = false;
            this.LB_Tittle.Font = new System.Drawing.Font("Segoe UI Emoji", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Tittle.GradiantColor = true;
            this.LB_Tittle.GradiantColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.LB_Tittle.GradiantColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(135)))));
            this.LB_Tittle.GradiantMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.LB_Tittle.Location = new System.Drawing.Point(61, 36);
            this.LB_Tittle.Name = "LB_Tittle";
            this.LB_Tittle.Size = new System.Drawing.Size(281, 38);
            this.LB_Tittle.TabIndex = 4;
            this.LB_Tittle.Text = "[SKYNET] Auto Click";
            this.LB_Tittle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LB_Tittle.TextColor = System.Drawing.SystemColors.ControlText;
            this.LB_Tittle.TextColor_MouseHover = System.Drawing.SystemColors.ControlText;
            // 
            // skyneT_Label1
            // 
            this.skyneT_Label1.AutoSize = true;
            this.skyneT_Label1.ChangeColor = false;
            this.skyneT_Label1.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skyneT_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.skyneT_Label1.GradiantColor = false;
            this.skyneT_Label1.GradiantColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.skyneT_Label1.GradiantColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(135)))));
            this.skyneT_Label1.GradiantMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.skyneT_Label1.Location = new System.Drawing.Point(64, 91);
            this.skyneT_Label1.Name = "skyneT_Label1";
            this.skyneT_Label1.Size = new System.Drawing.Size(77, 17);
            this.skyneT_Label1.TabIndex = 5;
            this.skyneT_Label1.Text = "How to use:";
            this.skyneT_Label1.TextColor = System.Drawing.SystemColors.ControlText;
            this.skyneT_Label1.TextColor_MouseHover = System.Drawing.SystemColors.ControlText;
            // 
            // skyneT_Label2
            // 
            this.skyneT_Label2.AutoSize = true;
            this.skyneT_Label2.ChangeColor = false;
            this.skyneT_Label2.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skyneT_Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.skyneT_Label2.GradiantColor = false;
            this.skyneT_Label2.GradiantColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.skyneT_Label2.GradiantColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(135)))));
            this.skyneT_Label2.GradiantMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.skyneT_Label2.Location = new System.Drawing.Point(64, 133);
            this.skyneT_Label2.Name = "skyneT_Label2";
            this.skyneT_Label2.Size = new System.Drawing.Size(169, 17);
            this.skyneT_Label2.TabIndex = 6;
            this.skyneT_Label2.Text = "Press HOME button to start";
            this.skyneT_Label2.TextColor = System.Drawing.SystemColors.ControlText;
            this.skyneT_Label2.TextColor_MouseHover = System.Drawing.SystemColors.ControlText;
            // 
            // skyneT_Label3
            // 
            this.skyneT_Label3.AutoSize = true;
            this.skyneT_Label3.ChangeColor = false;
            this.skyneT_Label3.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skyneT_Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.skyneT_Label3.GradiantColor = false;
            this.skyneT_Label3.GradiantColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.skyneT_Label3.GradiantColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(135)))));
            this.skyneT_Label3.GradiantMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.skyneT_Label3.Location = new System.Drawing.Point(64, 153);
            this.skyneT_Label3.Name = "skyneT_Label3";
            this.skyneT_Label3.Size = new System.Drawing.Size(157, 17);
            this.skyneT_Label3.TabIndex = 7;
            this.skyneT_Label3.Text = "Press END button to stop";
            this.skyneT_Label3.TextColor = System.Drawing.SystemColors.ControlText;
            this.skyneT_Label3.TextColor_MouseHover = System.Drawing.SystemColors.ControlText;
            // 
            // LB_Capture
            // 
            this.LB_Capture.AutoSize = true;
            this.LB_Capture.ChangeColor = false;
            this.LB_Capture.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Capture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.LB_Capture.GradiantColor = false;
            this.LB_Capture.GradiantColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.LB_Capture.GradiantColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(135)))));
            this.LB_Capture.GradiantMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.LB_Capture.Location = new System.Drawing.Point(64, 113);
            this.LB_Capture.Name = "LB_Capture";
            this.LB_Capture.Size = new System.Drawing.Size(284, 17);
            this.LB_Capture.TabIndex = 8;
            this.LB_Capture.Text = "Press INSERT button to capture mouse location";
            this.LB_Capture.TextColor = System.Drawing.SystemColors.ControlText;
            this.LB_Capture.TextColor_MouseHover = System.Drawing.SystemColors.ControlText;
            // 
            // LB_CurrentLocation
            // 
            this.LB_CurrentLocation.AutoSize = true;
            this.LB_CurrentLocation.ChangeColor = false;
            this.LB_CurrentLocation.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_CurrentLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.LB_CurrentLocation.GradiantColor = false;
            this.LB_CurrentLocation.GradiantColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.LB_CurrentLocation.GradiantColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(135)))));
            this.LB_CurrentLocation.GradiantMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.LB_CurrentLocation.Location = new System.Drawing.Point(64, 215);
            this.LB_CurrentLocation.Name = "LB_CurrentLocation";
            this.LB_CurrentLocation.Size = new System.Drawing.Size(101, 17);
            this.LB_CurrentLocation.TabIndex = 9;
            this.LB_CurrentLocation.Text = "Current location";
            this.LB_CurrentLocation.TextColor = System.Drawing.SystemColors.ControlText;
            this.LB_CurrentLocation.TextColor_MouseHover = System.Drawing.SystemColors.ControlText;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(393, 253);
            this.Controls.Add(this.LB_CurrentLocation);
            this.Controls.Add(this.LB_Capture);
            this.Controls.Add(this.skyneT_Label3);
            this.Controls.Add(this.skyneT_Label2);
            this.Controls.Add(this.skyneT_Label1);
            this.Controls.Add(this.LB_Tittle);
            this.Controls.Add(this.skyneT_Button1);
            this.Controls.Add(this.panel1);
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Controls.SKYNET_MinimizeBox MinimizeBox;
        private Controls.SKYNET_CloseBox CloseBox;
        private Controls.SKYNET_Button skyneT_Button1;
        private Controls.SKYNET_Label LB_Tittle;
        private Controls.SKYNET_Label skyneT_Label1;
        private Controls.SKYNET_Label skyneT_Label2;
        private Controls.SKYNET_Label skyneT_Label3;
        private Controls.SKYNET_Label LB_Capture;
        private Controls.SKYNET_Label LB_CurrentLocation;
    }
}

