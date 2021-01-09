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
            this.btnXepThoiKhoaBieu = new System.Windows.Forms.Button();
            this.btnQuanLyMonCuaKhoi = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXepThoiKhoaBieu
            // 
            this.btnXepThoiKhoaBieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXepThoiKhoaBieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXepThoiKhoaBieu.Location = new System.Drawing.Point(217, 3);
            this.btnXepThoiKhoaBieu.Name = "btnXepThoiKhoaBieu";
            this.btnXepThoiKhoaBieu.Size = new System.Drawing.Size(208, 56);
            this.btnXepThoiKhoaBieu.TabIndex = 0;
            this.btnXepThoiKhoaBieu.Text = "Xếp thời khóa biểu";
            this.btnXepThoiKhoaBieu.UseVisualStyleBackColor = true;
            this.btnXepThoiKhoaBieu.Click += new System.EventHandler(this.btnXepThoiKhoaBieu_Click);
            // 
            // btnQuanLyMonCuaKhoi
            // 
            this.btnQuanLyMonCuaKhoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuanLyMonCuaKhoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyMonCuaKhoi.Location = new System.Drawing.Point(3, 3);
            this.btnQuanLyMonCuaKhoi.Name = "btnQuanLyMonCuaKhoi";
            this.btnQuanLyMonCuaKhoi.Size = new System.Drawing.Size(208, 56);
            this.btnQuanLyMonCuaKhoi.TabIndex = 1;
            this.btnQuanLyMonCuaKhoi.Text = "Quản lý môn khối";
            this.btnQuanLyMonCuaKhoi.UseVisualStyleBackColor = true;
            this.btnQuanLyMonCuaKhoi.Click += new System.EventHandler(this.btnQuanLyMonCuaKhoi_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnQuanLyMonCuaKhoi, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnXepThoiKhoaBieu, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(428, 125);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 125);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmMain";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnXepThoiKhoaBieu;
        private System.Windows.Forms.Button btnQuanLyMonCuaKhoi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}