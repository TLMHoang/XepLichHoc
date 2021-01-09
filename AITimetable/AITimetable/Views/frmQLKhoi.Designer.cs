namespace AITimetable
{
    partial class frmQLKhoi
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
            this.cbxKhoi = new System.Windows.Forms.ComboBox();
            this.lstbHave = new System.Windows.Forms.ListBox();
            this.lstbNotHave = new System.Windows.Forms.ListBox();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxKhoi
            // 
            this.cbxKhoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxKhoi.FormattingEnabled = true;
            this.cbxKhoi.Location = new System.Drawing.Point(189, 12);
            this.cbxKhoi.Name = "cbxKhoi";
            this.cbxKhoi.Size = new System.Drawing.Size(121, 28);
            this.cbxKhoi.TabIndex = 0;
            this.cbxKhoi.SelectedIndexChanged += new System.EventHandler(this.cbxKhoi_SelectedIndexChanged);
            // 
            // lstbHave
            // 
            this.lstbHave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbHave.FormattingEnabled = true;
            this.lstbHave.ItemHeight = 20;
            this.lstbHave.Location = new System.Drawing.Point(12, 55);
            this.lstbHave.Name = "lstbHave";
            this.lstbHave.Size = new System.Drawing.Size(240, 344);
            this.lstbHave.TabIndex = 1;
            this.lstbHave.SelectedIndexChanged += new System.EventHandler(this.lstbHave_SelectedIndexChanged);
            // 
            // lstbNotHave
            // 
            this.lstbNotHave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbNotHave.FormattingEnabled = true;
            this.lstbNotHave.ItemHeight = 20;
            this.lstbNotHave.Location = new System.Drawing.Point(259, 55);
            this.lstbNotHave.Name = "lstbNotHave";
            this.lstbNotHave.Size = new System.Drawing.Size(240, 344);
            this.lstbNotHave.TabIndex = 1;
            this.lstbNotHave.SelectedIndexChanged += new System.EventHandler(this.lstbNotHave_SelectedIndexChanged);
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.cbxKhoi);
            this.pnlForm.Controls.Add(this.lstbNotHave);
            this.pnlForm.Controls.Add(this.lstbHave);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(506, 411);
            this.pnlForm.TabIndex = 2;
            // 
            // frmQLKhoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(506, 411);
            this.Controls.Add(this.pnlForm);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQLKhoi";
            this.Text = "Quản lý môn học của khối";
            this.Load += new System.EventHandler(this.frmQLKhoi_Load);
            this.pnlForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxKhoi;
        private System.Windows.Forms.ListBox lstbHave;
        private System.Windows.Forms.ListBox lstbNotHave;
        private System.Windows.Forms.Panel pnlForm;
    }
}