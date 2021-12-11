
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
            this.CloseBox = new SKYNET.Controls.SKYNET_CloseBox();
            this.BT_Apply = new SKYNET.Controls.SKYNET_Button();
            this.skyneT_Button1 = new SKYNET.Controls.SKYNET_Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CloseBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 25);
            this.panel1.TabIndex = 2;
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.CloseBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.CloseBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.CloseBox.Location = new System.Drawing.Point(284, 0);
            this.CloseBox.MaximumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.MinimumSize = new System.Drawing.Size(34, 26);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(34, 26);
            this.CloseBox.TabIndex = 4;
            this.CloseBox.Clicked += new System.EventHandler(this.CloseBox_Clicked);
            // 
            // BT_Apply
            // 
            this.BT_Apply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.BT_Apply.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Apply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Apply.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BT_Apply.ForeColor = System.Drawing.Color.White;
            this.BT_Apply.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Apply.ImageAlignment = SKYNET.Controls.SKYNET_Button.ImgAlign.Left;
            this.BT_Apply.ImageIcon = null;
            this.BT_Apply.Location = new System.Drawing.Point(54, 326);
            this.BT_Apply.MenuMode = false;
            this.BT_Apply.Name = "BT_Apply";
            this.BT_Apply.Rounded = false;
            this.BT_Apply.Size = new System.Drawing.Size(91, 28);
            this.BT_Apply.Style = SKYNET.Controls.SKYNET_Button._Style.TextOnly;
            this.BT_Apply.TabIndex = 3;
            this.BT_Apply.Text = "Apply";
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
            this.skyneT_Button1.Location = new System.Drawing.Point(173, 326);
            this.skyneT_Button1.MenuMode = false;
            this.skyneT_Button1.Name = "skyneT_Button1";
            this.skyneT_Button1.Rounded = false;
            this.skyneT_Button1.Size = new System.Drawing.Size(91, 28);
            this.skyneT_Button1.Style = SKYNET.Controls.SKYNET_Button._Style.TextOnly;
            this.skyneT_Button1.TabIndex = 4;
            this.skyneT_Button1.Text = "Cancel";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(318, 366);
            this.Controls.Add(this.skyneT_Button1);
            this.Controls.Add(this.BT_Apply);
            this.Controls.Add(this.panel1);
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Controls.SKYNET_CloseBox CloseBox;
        private Controls.SKYNET_Button BT_Apply;
        private Controls.SKYNET_Button skyneT_Button1;
    }
}

