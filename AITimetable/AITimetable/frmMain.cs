using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryAI;
using LibraryAI.Excel;
using OfficeOpenXml;

namespace AITimetable
{
    public partial class frmMain : Form
    {
        private List<List<TextBox>> matrix;

       
        public frmMain()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;

            Program.lstTeacher = new Teacher().CreateDataTeacher(Program.lstSubjects);
            Program.aLstTeachers = new Teacher().CreateDataTestDT(Program.lstSubjects, Program.lstTeacher);
            Program.lstClasses = new Class().createDataTest(Program.lstGrades);

            AddItemComboBox();
        }

        public List<List<TextBox>> Matrix { get => matrix; set => matrix = value; }

        private void AddItemComboBox()
        {
            string[] iCbx = new string[Program.lstClasses.Count];

            for (int i = 0; i < Program.lstClasses.Count; i++)
            {
                iCbx[i] = Program.lstClasses[i].Name;
            }
            cbxClass.Items.AddRange(iCbx);

            
        }


        // xép thời Khóa biểu
        private void btnTKB_Click(object sender, EventArgs e)
        {
            new DivideTeacher().Handle(Program.aLstTeachers, Program.lstClasses);
            new TimeTable().XepLich(Program.lstClasses, Program.lstTeacher, Program.lstSubjects);
            MessageBox.Show("OK");


        }

        private void cbxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.SClass = Program.lstClasses.FirstOrDefault(p => p.Name.Equals(cbxClass.SelectedItem.ToString()));
            LoadTimeTable(Program.SClass.TimetableClass);

            cbxGiaoVien.Items.Clear();
            string[] iCb = new string[Program.SClass.listTeacher.Count];

            for (int i = 0; i < Program.SClass.listTeacher.Count; i++)
            {
                iCb[i] = Program.lstTeacher.FirstOrDefault(p => p.ID == Program.SClass.listTeacher[i]).Name;
            }
            cbxGiaoVien.Items.AddRange(iCb);
        }

        private string GetNameSub(int IDSub)
        {
            switch (IDSub)
            {
                case 0:
                case -1:
                    return "";
                case -99:
                    return "Chào Cờ";
                case -98:
                    return "SHL";
                default:
                    return Program.lstSubjects.FirstOrDefault(c => c.ID == IDSub).Name;
            }
        }

        private string GetNameClass(int IDClass)
        {
            if (IDClass == -1)
            {
                return "";
            }
            else
            {
                return Program.lstClasses.FirstOrDefault(c => c.ID == IDClass).Name;
            }
        }

        private void LoadTimeTable(int[][] TT)  // tạo ô thời khóa biểu lớp
        {
            tlpTKB.Controls.Clear();
            Matrix = new List<List<TextBox>>();

            for (int i = 0; i < 10; i++)
            {
                Matrix.Add(new List<TextBox>());

                for (int j = 0; j < 7; j++)
                {
                    var textbox = new TextBox
                    {
                        Dock = DockStyle.Fill,
                        Font = new Font("Time New Roman", 14f, FontStyle.Bold),
                        ReadOnly = true,
                        Text = GetNameSub(TT[j][i]),
                        TextAlign = HorizontalAlignment.Center,
                        Tag = i.ToString()
                    };
                    tlpTKB.Controls.Add(textbox);
                    Matrix[i].Add(textbox);

                }
            }

        }

        private void LoadTimeTableTeacher(int[][] TT)  // tạo ô thời khóa biểu lớp
        {
            tlpGiaoVien.Controls.Clear();
            Matrix = new List<List<TextBox>>();

            for (int i = 0; i < 10; i++)
            {
                Matrix.Add(new List<TextBox>());

                for (int j = 0; j < 7; j++)
                {
                    var textbox = new TextBox
                    {
                        Dock = DockStyle.Fill,
                        Font = new Font("Time New Roman", 14f, FontStyle.Bold),
                        ReadOnly = true,
                        Text = GetNameClass(TT[j][i]),
                        TextAlign = HorizontalAlignment.Center,
                        Tag = i.ToString()
                    };
                    tlpGiaoVien.Controls.Add(textbox);
                    Matrix[i].Add(textbox);

                }
            }

        }

        private Color SetColor(string nSub)
        {
            switch (nSub)
            {
                case "Toán":
                    return Color.Red;
                case "Lý":
                    return Color.Yellow;
                case "Hóa":
                    return Color.Blue;
                case "Sinh":
                    return Color.Green;
                case "Sử":
                    return Color.Gray;
                case "Địa":
                    return Color.Pink;
                case "Văn":
                    return Color.Orange;
                case "Anh":
                    return Color.Purple;
                case "Công Nghệ":
                    return Color.AliceBlue;
                case "GDCD":
                    return Color.LightGreen;
                case "Thể giục":
                    return Color.LightPink;
                default:
                    return Color.Silver;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void cbxGiaoVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbx = sender as ComboBox;


            Teacher t = Program.lstTeacher.FirstOrDefault(p => p.ID == Program.SClass.listTeacher[cbx.SelectedIndex]);

            lblMon.Text = "Thời khóa biểu giáo viên " + Program.lstSubjects.FirstOrDefault(p=>p.ID == t.IDSubject).Name;


            LoadTimeTableTeacher(t.Timetable);
        }

        private void frmMain_LocationChanged(object sender, EventArgs e)
        {
            Form f = this;

            if (this.Location.X < 0 && this.Location.Y < 0)
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] a = new int[10];
            Class c = Program.lstClasses[0];
            frmChangeSub f = new frmChangeSub();
            
            f.ShowDialog();


        }

        private void btnExprotEXC_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName.Length > 0)
            {
                new ExportExcel(saveFileDialog.FileName, Program.lstSubjects, Program.lstClasses).ExportFile();
            }
        }
    }
}
