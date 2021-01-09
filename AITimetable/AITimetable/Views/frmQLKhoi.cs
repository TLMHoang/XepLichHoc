using AITimetable.Database;
using AITimetable.Models;
using AITimetable.Views.ControlCustom;
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
    public partial class frmQLKhoi : Form
    {
        DBContext db = new DBContext();
        List<MonHoc> lstMon = new List<MonHoc>();
        Khoi khoiSelect;
        uctSoLuongTiet uct = new uctSoLuongTiet();
        uctSoLuongTiet uctEdit = new uctSoLuongTiet();
        mgsCustomForQLKhoi messge = new mgsCustomForQLKhoi();


        public frmQLKhoi()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
        }

        private void frmQLKhoi_Load(object sender, EventArgs e)
        {
            lstMon = db.MonHocs.ToList();

            cbxKhoi.Items.AddRange(db.Khois.ToList().Where(p=>p.TenKhoi != "null").ToArray());
            cbxKhoi.SelectedIndex = 0;
            uct.Visible = false;
            uctEdit.Visible = false;
            uct.Location = uctEdit.Location = MiddleCenterLocation(this.Size, uct.Size);
            uct.VisibleChanged += Uct_VisibleChanged;
            uctEdit.VisibleChanged += UctEdit_VisibleChanged;
            this.Controls.Add(uct);
            this.Controls.Add(uctEdit);
        }

        private void UctEdit_VisibleChanged(object sender, EventArgs e)
        {
            if (uctEdit.Visible)
            {
                uctEdit.lblMon.Text = Program.monCuaKhoi.MonHoc.TenMon;
                uctEdit.numWeek.Value = (int)Program.monCuaKhoi.TietTrongTuan;
                uctEdit.numDay.Value = (int)Program.monCuaKhoi.TIetTrongNgay;
            }
            pnlForm.Visible = !uctEdit.Visible;
        }

        private void Uct_VisibleChanged(object sender, EventArgs e)
        {
            if (uct.Visible)
            {
                uct.lblMon.Text = Program.monCuaKhoi.MonHoc.TenMon;
                uct.numWeek.Value = 1;
            }
            pnlForm.Visible = !uct.Visible;
            
        }

        

        private void cbxKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstbHave.Items.Clear();
            lstbNotHave.Items.Clear();
            khoiSelect = (Khoi)cbxKhoi.SelectedItem;
            List<MonHoc> monHocs = new MonCuaKhoiModels().GetMonHoc(khoiSelect.ID);
            lstbHave.Items.AddRange(monHocs.ToArray());

            var difList = lstMon.Where(a => !monHocs.Any(a1 => a1.ID == a.ID))
            .Union(monHocs.Where(a => !lstMon.Any(a1 => a1.ID == a.ID))).ToArray();

            lstbNotHave.Items.AddRange(difList);
        }

        private void lstbHave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstbHave.SelectedIndex != -1)
            {
                Program.monCuaKhoi = db.MonCuaKhois.FirstOrDefault(p => p.IDKhoi == khoiSelect.ID && p.IDMon == ((MonHoc)lstbHave.SelectedItem).ID);

                DialogResult result = messge.ShowDialog();
                switch (result)
                {
                    case DialogResult.Yes: // Sửa
                        {
                            uctEdit.Visible = true;

                            Task.Run(() =>
                            {
                                while (true)
                                {
                                    if (uctEdit.YesNo == 1)
                                    {
                                        uctEdit.YesNo = 0;
                                        break;
                                    }
                                    if (uctEdit.YesNo == 2)
                                    {
                                        db.SaveChanges();
                                        uctEdit.YesNo = 0;
                                        break;
                                    }
                                }
                            });
                            break;
                        }
                    case DialogResult.No: // Xóa
                        {
                            lstbNotHave.Items.Add((MonHoc)lstbHave.SelectedItem);
                            lstbHave.Items.Remove(lstbHave.SelectedItem);

                            db.MonCuaKhois.Remove(Program.monCuaKhoi);
                            break;
                        }
                        
                        
                    default: // Quay lai;
                        break;
                }
            }
        }

        private void lstbNotHave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstbNotHave.SelectedIndex != -1)
            {
                Program.monCuaKhoi = new MonCuaKhoi();
                Program.monCuaKhoi.MonHoc = (MonHoc)lstbNotHave.SelectedItem;

                Program.monCuaKhoi.IDKhoi = khoiSelect.ID;
                Program.monCuaKhoi.IDMon = Program.monCuaKhoi.MonHoc.ID;

                uct.Visible = true;

                Task.Run(() =>
                {
                    while (true)
                    {
                        if (uct.YesNo == 1)
                        {
                            uct.YesNo = 0;
                            break;
                        }
                        if (uct.YesNo == 2)
                        {
                            db.MonCuaKhois.Add(Program.monCuaKhoi);
                            db.SaveChanges();


                            lstbHave.Items.Add((MonHoc)lstbNotHave.SelectedItem);
                            lstbNotHave.Items.Remove(lstbNotHave.SelectedItem);

                            uct.YesNo = 0;
                            break;
                        }
                    }
                });
            }
        }

        private Point MiddleCenterLocation(Size parent, Size child)
        {
            Point point = new Point();

            point.X = (int)((parent.Width - child.Width) / 2);
            point.Y = (int)((parent.Height - child.Height) / 2) - 50;

            return point;
        }
    }
}
