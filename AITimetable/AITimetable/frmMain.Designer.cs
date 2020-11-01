namespace AITimetable
{
    partial class frmMain
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
            this.btnChiaGiaoVien = new System.Windows.Forms.Button();
            this.rtxtData = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnChiaGiaoVien
            // 
            this.btnChiaGiaoVien.Location = new System.Drawing.Point(12, 12);
            this.btnChiaGiaoVien.Name = "btnChiaGiaoVien";
            this.btnChiaGiaoVien.Size = new System.Drawing.Size(169, 23);
            this.btnChiaGiaoVien.TabIndex = 0;
            this.btnChiaGiaoVien.Text = "Phân Chia GV";
            this.btnChiaGiaoVien.UseVisualStyleBackColor = true;
            this.btnChiaGiaoVien.Click += new System.EventHandler(this.btnChiaGiaoVien_Click);
            // 
            // rtxtData
            // 
            this.rtxtData.Location = new System.Drawing.Point(284, 21);
            this.rtxtData.Name = "rtxtData";
            this.rtxtData.Size = new System.Drawing.Size(400, 342);
            this.rtxtData.TabIndex = 1;
            this.rtxtData.Text = "";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 375);
            this.Controls.Add(this.rtxtData);
            this.Controls.Add(this.btnChiaGiaoVien);
            this.Name = "frmMain";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChiaGiaoVien;
        private System.Windows.Forms.RichTextBox rtxtData;
    }
}

