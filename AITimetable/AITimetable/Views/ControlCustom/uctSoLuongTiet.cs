using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AITimetable.Views.ControlCustom
{
    public partial class uctSoLuongTiet : UserControl
    {
        public int YesNo = 0;
        public uctSoLuongTiet()
        {
            InitializeComponent();

            
        }

        private void uctSoLuongTiet_Load(object sender, EventArgs e)
        {
            
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            YesNo = 1;
            this.Visible = false;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Program.monCuaKhoi.TIetTrongNgay = (int)numDay.Value;
            Program.monCuaKhoi.TietTrongTuan = (int)numWeek.Value;
            YesNo = 2;

            this.Visible = false;
        }

        private void numWeek_ValueChanged(object sender, EventArgs e)
        {
            numDay.Maximum = numWeek.Value;
        }
    }
}
