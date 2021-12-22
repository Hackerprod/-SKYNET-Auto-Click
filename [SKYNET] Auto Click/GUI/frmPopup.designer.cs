using SKYNET.Controls;

partial class frmPopup
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.acceptBtn = new System.Windows.Forms.Button();
            this.LB_Action = new System.Windows.Forms.Label();
            this.LB_Time = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // acceptBtn
            // 
            this.acceptBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptBtn.Location = new System.Drawing.Point(485, 375);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(75, 23);
            this.acceptBtn.TabIndex = 16;
            this.acceptBtn.Text = "button1";
            this.acceptBtn.UseVisualStyleBackColor = true;
            // 
            // LB_Action
            // 
            this.LB_Action.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(70)))), ((int)(((byte)(82)))));
            this.LB_Action.Dock = System.Windows.Forms.DockStyle.Top;
            this.LB_Action.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Action.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LB_Action.Location = new System.Drawing.Point(1, 1);
            this.LB_Action.Name = "LB_Action";
            this.LB_Action.Size = new System.Drawing.Size(169, 33);
            this.LB_Action.TabIndex = 17;
            this.LB_Action.Text = "RECORDING";
            this.LB_Action.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_Action.MouseLeave += new System.EventHandler(this.Mouse_Leave);
            this.LB_Action.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mouse_Move);
            // 
            // LB_Time
            // 
            this.LB_Time.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.LB_Time.Dock = System.Windows.Forms.DockStyle.Top;
            this.LB_Time.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LB_Time.Location = new System.Drawing.Point(1, 34);
            this.LB_Time.Name = "LB_Time";
            this.LB_Time.Size = new System.Drawing.Size(169, 29);
            this.LB_Time.TabIndex = 18;
            this.LB_Time.Text = "00:00:00:00";
            this.LB_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_Time.MouseLeave += new System.EventHandler(this.Mouse_Leave);
            this.LB_Time.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mouse_Move);
            // 
            // frmPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(171, 64);
            this.Controls.Add(this.LB_Time);
            this.Controls.Add(this.LB_Action);
            this.Controls.Add(this.acceptBtn);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPopup";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmPopup_Load);
            this.MouseLeave += new System.EventHandler(this.Mouse_Leave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mouse_Move);
            this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Button acceptBtn;
    private System.Windows.Forms.Label LB_Action;
    public System.Windows.Forms.Label LB_Time;
}
