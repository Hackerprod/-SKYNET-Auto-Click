
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseBox = new SKYNET.Controls.SKYNET_CloseBox();
            this.BT_Apply = new SKYNET.Controls.SKYNET_Button();
            this.BT_Cancel = new SKYNET.Controls.SKYNET_Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Time = new SKYNET.Controls.SKYNET_TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LB_Capture = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LB_Start = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LB_Stop = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.CloseBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
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
            this.BT_Apply.Location = new System.Drawing.Point(96, 330);
            this.BT_Apply.MenuMode = false;
            this.BT_Apply.Name = "BT_Apply";
            this.BT_Apply.Rounded = false;
            this.BT_Apply.Size = new System.Drawing.Size(91, 28);
            this.BT_Apply.Style = SKYNET.Controls.SKYNET_Button._Style.TextOnly;
            this.BT_Apply.TabIndex = 3;
            this.BT_Apply.Text = "Apply";
            this.BT_Apply.Click += new System.EventHandler(this.BT_Apply_Click);
            // 
            // BT_Cancel
            // 
            this.BT_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.BT_Cancel.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Cancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BT_Cancel.ForeColor = System.Drawing.Color.White;
            this.BT_Cancel.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Cancel.ImageAlignment = SKYNET.Controls.SKYNET_Button.ImgAlign.Left;
            this.BT_Cancel.ImageIcon = null;
            this.BT_Cancel.Location = new System.Drawing.Point(198, 330);
            this.BT_Cancel.MenuMode = false;
            this.BT_Cancel.Name = "BT_Cancel";
            this.BT_Cancel.Rounded = false;
            this.BT_Cancel.Size = new System.Drawing.Size(91, 28);
            this.BT_Cancel.Style = SKYNET.Controls.SKYNET_Button._Style.TextOnly;
            this.BT_Cancel.TabIndex = 4;
            this.BT_Cancel.Text = "Cancel";
            this.BT_Cancel.Click += new System.EventHandler(this.BT_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label1.Location = new System.Drawing.Point(25, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Time elapsed between Clicks ";
            // 
            // TB_Time
            // 
            this.TB_Time.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.TB_Time.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.TB_Time.Color = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.TB_Time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.TB_Time.IsPassword = false;
            this.TB_Time.Location = new System.Drawing.Point(28, 68);
            this.TB_Time.Logo = global::SKYNET.Properties.Resources.present_64px;
            this.TB_Time.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.TB_Time.Name = "TB_Time";
            this.TB_Time.ShowLogo = true;
            this.TB_Time.Size = new System.Drawing.Size(261, 35);
            this.TB_Time.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label2.Location = new System.Drawing.Point(25, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Key to capture click coordinates ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.panel2.Controls.Add(this.LB_Capture);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Location = new System.Drawing.Point(28, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 34);
            this.panel2.TabIndex = 8;
            this.panel2.Click += new System.EventHandler(this.LB_Capture_Click);
            // 
            // LB_Capture
            // 
            this.LB_Capture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LB_Capture.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Capture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.LB_Capture.Location = new System.Drawing.Point(3, 8);
            this.LB_Capture.Name = "LB_Capture";
            this.LB_Capture.Size = new System.Drawing.Size(258, 17);
            this.LB_Capture.TabIndex = 8;
            this.LB_Capture.Text = "INSERT";
            this.LB_Capture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_Capture.Click += new System.EventHandler(this.LB_Capture_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.panel3.Controls.Add(this.LB_Start);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(30, 200);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(261, 34);
            this.panel3.TabIndex = 10;
            this.panel3.Click += new System.EventHandler(this.LB_Start_Click);
            // 
            // LB_Start
            // 
            this.LB_Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LB_Start.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Start.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.LB_Start.Location = new System.Drawing.Point(3, 8);
            this.LB_Start.Name = "LB_Start";
            this.LB_Start.Size = new System.Drawing.Size(258, 17);
            this.LB_Start.TabIndex = 8;
            this.LB_Start.Text = "HOME";
            this.LB_Start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_Start.Click += new System.EventHandler(this.LB_Start_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label4.Location = new System.Drawing.Point(27, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Key to start click bucle";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.panel4.Controls.Add(this.LB_Stop);
            this.panel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel4.Location = new System.Drawing.Point(28, 264);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(261, 34);
            this.panel4.TabIndex = 12;
            this.panel4.Click += new System.EventHandler(this.LB_Stop_Click);
            // 
            // LB_Stop
            // 
            this.LB_Stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LB_Stop.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Stop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.LB_Stop.Location = new System.Drawing.Point(3, 8);
            this.LB_Stop.Name = "LB_Stop";
            this.LB_Stop.Size = new System.Drawing.Size(258, 17);
            this.LB_Stop.TabIndex = 8;
            this.LB_Stop.Text = "END";
            this.LB_Stop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_Stop.Click += new System.EventHandler(this.LB_Stop_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label6.Location = new System.Drawing.Point(25, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Key to stop click bucle";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(329, 338);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(100, 20);
            this.textBox.TabIndex = 13;
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(318, 383);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_Time);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BT_Cancel);
            this.Controls.Add(this.BT_Apply);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Controls.SKYNET_CloseBox CloseBox;
        private Controls.SKYNET_Button BT_Apply;
        private Controls.SKYNET_Button BT_Cancel;
        private System.Windows.Forms.Label label1;
        private Controls.SKYNET_TextBox TB_Time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LB_Capture;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LB_Start;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label LB_Stop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox;
    }
}

