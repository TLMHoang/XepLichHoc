namespace AITimetable.Views.ControlCustom
{
    partial class uctSoLuongTiet
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numWeek = new System.Windows.Forms.NumericUpDown();
            this.numDay = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMon = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numWeek
            // 
            this.numWeek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numWeek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numWeek.Location = new System.Drawing.Point(175, 68);
            this.numWeek.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.numWeek.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numWeek.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeek.Name = "numWeek";
            this.numWeek.Size = new System.Drawing.Size(81, 20);
            this.numWeek.TabIndex = 0;
            this.numWeek.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numWeek.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeek.ValueChanged += new System.EventHandler(this.numWeek_ValueChanged);
            // 
            // numDay
            // 
            this.numDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numDay.Location = new System.Drawing.Point(175, 112);
            this.numDay.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.numDay.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDay.Name = "numDay";
            this.numDay.Size = new System.Drawing.Size(81, 20);
            this.numDay.TabIndex = 0;
            this.numDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số môn trong tuần";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.lblMon, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numDay, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.numWeek, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnYes, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnNo, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 178);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblMon
            // 
            this.lblMon.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblMon, 3);
            this.lblMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMon.Location = new System.Drawing.Point(3, 0);
            this.lblMon.Name = "lblMon";
            this.lblMon.Size = new System.Drawing.Size(253, 53);
            this.lblMon.TabIndex = 2;
            this.lblMon.Text = "N/A";
            this.lblMon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 44);
            this.label3.TabIndex = 3;
            this.label3.Text = "Số môn trong ngày";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnYes
            // 
            this.btnYes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnYes.Location = new System.Drawing.Point(175, 144);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(81, 31);
            this.btnYes.TabIndex = 4;
            this.btnYes.Text = "Đồng ý";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNo.Location = new System.Drawing.Point(3, 144);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(80, 31);
            this.btnNo.TabIndex = 4;
            this.btnNo.Text = "Thoát";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // uctSoLuongTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "uctSoLuongTiet";
            this.Size = new System.Drawing.Size(259, 178);
            this.Load += new System.EventHandler(this.uctSoLuongTiet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.NumericUpDown numWeek;
        public System.Windows.Forms.NumericUpDown numDay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label lblMon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
    }
}
