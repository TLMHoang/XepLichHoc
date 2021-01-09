using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AITimetable
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnQuanLyMonCuaKhoi_Click(object sender, EventArgs e)
        {
            frmQLKhoi f = new frmQLKhoi();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnXepThoiKhoaBieu_Click(object sender, EventArgs e)
        {
            frmXepLich f = new frmXepLich();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            this.Hide();

            if (f.ShowDialog() == DialogResult.Yes)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }
        }
    }
}
