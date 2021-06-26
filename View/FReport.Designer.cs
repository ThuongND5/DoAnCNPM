namespace DoAnCNPM
{
    partial class FReport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.RP_gui = new System.Windows.Forms.Button();
            this.Btn_Huy = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 106);
            this.panel1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(291, 106);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // RP_gui
            // 
            this.RP_gui.Location = new System.Drawing.Point(309, 68);
            this.RP_gui.Name = "RP_gui";
            this.RP_gui.Size = new System.Drawing.Size(56, 50);
            this.RP_gui.TabIndex = 1;
            this.RP_gui.Text = "Gửi";
            this.RP_gui.UseVisualStyleBackColor = true;
            this.RP_gui.Click += new System.EventHandler(this.RP_gui_Click);
            // 
            // Btn_Huy
            // 
            this.Btn_Huy.Location = new System.Drawing.Point(308, 12);
            this.Btn_Huy.Name = "Btn_Huy";
            this.Btn_Huy.Size = new System.Drawing.Size(56, 48);
            this.Btn_Huy.TabIndex = 1;
            this.Btn_Huy.Text = "Hủy";
            this.Btn_Huy.UseVisualStyleBackColor = true;
            this.Btn_Huy.Click += new System.EventHandler(this.Btn_Huy_Click);
            // 
            // FReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 130);
            this.Controls.Add(this.Btn_Huy);
            this.Controls.Add(this.RP_gui);
            this.Controls.Add(this.panel1);
            this.Name = "FReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button RP_gui;
        private System.Windows.Forms.Button Btn_Huy;
    }
}