using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AITimetable.Views.ControlCustom
{
    public partial class mgsCustomForQLKhoi : Form
    {
        public mgsCustomForQLKhoi()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;

        }
    }
}
