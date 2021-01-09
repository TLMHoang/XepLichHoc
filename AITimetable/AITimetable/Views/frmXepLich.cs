using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryAI;
using LibraryAI.Excel;
using OfficeOpenXml;

namespace AITimetable
{
    public partial class frmXepLich : Form
    {
        private List<List<Button>> matrix;
        private List<TimeTableTeacher> lstT;
        private List<int> lstbtn = new List<int>();
        private List<SPTag> lstTag = new List<SPTag>();
        private List<SPTag> Swap = new List<SPTag>();
        private List<SPTag> TSwap = new List<SPTag>();
        private Teacher STeacher = new Teacher();


        public frmXepLich()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;

            Program.lstTeacher = new Teacher().CreateDataTeacher(Program.lstSubjects);
            Program.aLstTeachers = new Teacher().CreateDataTestDT(Program.lstSubjects, Program.lstTeacher);
            Program.lstClasses = new Class().createDataTest(Program.lstGrades);

            AddItemComboBox();

            new DivideTeacher().Handle(Program.aLstTeachers, Program.lstClasses);
        }

        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }

        private void AddItemComboBox()
        {
            string[] iCbx = new string[Program.lstClasses.Count];

            for (int i = 0; i < Program.lstClasses.Count; i++)
            {
                iCbx[i] = Program.lstClasses[i].Name;
            }
            cbxClass.Items.AddRange(iCbx);

            cbxGiaoVien.Items.Clear();
            string[] iCb = new string[Program.lstTeacher.Count];

            for (int i = 0; i < Program.lstTeacher.Count; i++)
            {
                iCb[i] = Program.lstTeacher[i].Name + " - " + Program.lstSubjects.FirstOrDefault(p=>p.ID == Program.lstTeacher[i].IDSubject).Name + " - " + Program.lstTeacher[i].ID;
            }
            cbxGiaoVien.Items.AddRange(iCb);
        }


        // xép thời Khóa biểu
        private void btnTKB_Click(object sender, EventArgs e)
        {
            bool loop = true;
            while (loop)
            {
                foreach (Teacher t in Program.lstTeacher)
                {
                    t.ResetTT();
                }
                foreach (Class c in Program.lstClasses)
                {
                    c.ResetTT(Program.lstGrades);
                }


                new TimeTable().XepLich(Program.lstClasses, Program.lstTeacher, Program.lstSubjects);

                List<Test> tests = new Test().Check(Program.lstClasses, Program.lstTeacher, Program.lstSubjects);

                if (tests.Count > 0)
                {
                    string ErrorT = "Danh sách lỗi \n";
                    foreach (Test t in tests)
                    {
                        ErrorT += t.IDClass + " - " + t.IDTeacher + " - " + t.X + " - " + t.Y + "\n";
                    }

                    string filePath = "LogTime" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".txt";

                    FileStream fs = new FileStream(filePath, FileMode.Create);

                    StreamWriter streamWriter = new StreamWriter(fs, Encoding.UTF8);
                    streamWriter.WriteLine(ErrorT);

                    streamWriter.Flush();

                    fs.Close();
                }
                else
                {
                    loop = false;
                }
                
            }
            MessageBox.Show("Xếp thành công");
        }

        private void cbxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstT = new List<TimeTableTeacher>();
            Program.SClass = Program.lstClasses.FirstOrDefault(p => p.Name.Equals(cbxClass.SelectedItem.ToString()));
            lstT = new TimeTable().GetTimeTableTeachers(Program.SClass.listTeacher, Program.lstTeacher);
            LoadTimeTable(Program.SClass.TimetableClass);
            //cbxGiaoVien.Items.Clear();
            //string[] iCb = new string[Program.SClass.listTeacher.Count];

            //for (int i = 0; i < Program.SClass.listTeacher.Count; i++)
            //{
            //    iCb[i] = Program.lstTeacher.FirstOrDefault(p => p.ID == Program.SClass.listTeacher[i]).Name;
            //}
            //cbxGiaoVien.Items.AddRange(iCb);
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
            Matrix = new List<List<Button>>();

            for (int i = 0; i < 10; i++)
            {
                Matrix.Add(new List<Button>());

                for (int j = 0; j < 7; j++)
                {
                    var btn = new Button
                    {
                        Dock = DockStyle.Fill,
                        Font = new Font("Time New Roman", 12f, FontStyle.Bold),
                        Text = GetNameSub(TT[j][i]),
                        Margin = new Padding(0),
                        Padding = new Padding(0),
                        BackColor = SystemColors.Control
                    };
                    btn.Click += BtnTBC_Click;
                    var te = lstT.FirstOrDefault(p => p.IDSub == TT[j][i]);
                    int iDT = (te != null) ? te.IDTeacher : -1;
                    btn.Tag = new SPTag(iDT, TT[j][i], -1, j, i);
                    tlpTKB.Controls.Add(btn);
                    lstTag.Add(btn.Tag as SPTag);
                    Matrix[i].Add(btn);

                }
            }

        }


        
        //Event swap button

        #region Đảo  môn

        private void BtnTBC_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            SPTag t = btn.Tag as SPTag;
            if (t.IDTeacher > 0)
            {
                Teacher teacher = Program.lstTeacher.FirstOrDefault(p => p.ID == t.IDTeacher);
                btn.BackColor = Color.Red;
                Swap.Add(t);
            }

            switch (Swap.Count)
            {
                case 1:
                    {
                        Find(Program.lstGrades.FirstOrDefault(g => g.ID == Program.SClass.IDGrade).Morning, Program.lstSubjects.FirstOrDefault(s => s.ID == Swap[0].IDSub).SubMain, tlpTKB, Swap);
                        break;
                    }
                case 2:
                    {
                        HandleSwap(Swap, tlpTKB);
                        Swap = new List<SPTag>();
                        break;
                    }
                default:
                    break;
            }

        }


        private bool SwapSub(List<SPTag> swap)
        {
            SPTag SWS = swap[0];
            TimeTableTeacher ST = lstT.FirstOrDefault(t => t.IDTeacher == SWS.IDTeacher);
            SPTag SWT = swap[1];
            TimeTableTeacher TT = lstT.FirstOrDefault(t => t.IDTeacher == SWT.IDTeacher);

            if (SWS.X != SWT.X || SWS.Y != SWT.Y)
            {
                if (Program.SClass.TimetableClass[SWT.X][SWT.Y] != Program.SClass.TimetableClass[SWS.X][SWS.Y])
                {
                    if (ST.TT[SWT.X][SWT.Y] != -1 && ST.TT[SWT.X][SWT.Y] != Program.SClass.ID)
                    {
                        return false;
                    }
                    // Kieem tra còn null ko
                    if (TT.TT[SWS.X][SWS.Y] != -1 && TT.TT[SWS.X][SWS.Y] != Program.SClass.ID)
                    {
                        return false;
                    }

                    ST.TT[SWT.X][SWT.Y] = Program.SClass.ID;
                    TT.TT[SWS.X][SWS.Y] = Program.SClass.ID;
                    TT.TT[SWT.X][SWT.Y] = -1;
                    ST.TT[SWS.X][SWS.Y] = -1;

                    Program.SClass.TimetableClass[SWS.X][SWS.Y] = TT.IDSub;
                    Program.SClass.TimetableClass[SWT.X][SWT.Y] = ST.IDSub;

                    //var aVal = Program.lstClasses;
                    LoadTimeTable(Program.SClass.TimetableClass);
                }

            }

            return true;

        }

        private void RemoveHighlight(TableLayoutPanel tlp)
        {
            foreach (int i in lstbtn)
            {
                (tlp.Controls[i] as Button).BackColor = SystemColors.Control;
            }
        }

        private void Find(bool mor, bool SM, TableLayoutPanel tlp, List<SPTag> swap)
        {
            foreach (TimeTableTeacher item in lstT)
            {
                List<ExchangeLesson> lst = new List<ExchangeLesson>();
                if (item.IDTeacher != swap[0].IDTeacher) // Kiem tra xem phai mon dang doi hay ko
                {
                    //ktra gv co trong lich tai cai vi tri dang muon doi
                    if (item.TT[swap[0].X][swap[0].Y] == -1)
                    {
                        if (mor && SM || mor == false && SM == false)
                        {
                            for (int i = 0; i < Program.SClass.TimetableClass.Length - 1; i++)
                            {
                                for (int j = 0; j < 5; j++)
                                {
                                    if (Program.SClass.TimetableClass[i][j] == item.IDSub)
                                    {
                                        lst.Add(new ExchangeLesson(item.IDTeacher, i, j));
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < Program.SClass.TimetableClass.Length - 1; i++)
                            {
                                for (int j = 5; j < 10; j++)
                                {
                                    if (Program.SClass.TimetableClass[i][j] == item.IDSub)
                                    {
                                        lst.Add(new ExchangeLesson(item.IDTeacher, i, j));
                                    }
                                }
                            }
                        }

                        foreach (ExchangeLesson e in lst)
                        {
                            TimeTableTeacher sTeacher = lstT.FirstOrDefault(t => t.IDTeacher == swap[0].IDTeacher);
                            if (sTeacher.TT[e.X][e.Y] == -1)
                            {
                                int index = (e.Y * 7) + e.X;
                                Button btn = tlp.Controls[index] as Button;
                                lstbtn.Add(index);
                                btn.BackColor = Color.LightGreen;
                            }
                        }
                    }
                }
            }
        }


        private void HandleSwap(List<SPTag> swap, TableLayoutPanel tlp)
        {
            if (swap[0] != swap[1])
            {
                foreach (SPTag sP in swap)
                {
                    int index = (sP.Y * 7) + sP.X;
                    Button b = tlp.Controls[index] as Button;
                    b.BackColor = SystemColors.Control;
                }

                if (SwapSub(swap))
                {
                    LoadTimeTableTeacher(Program.lstTeacher.FirstOrDefault(p => p.ID == swap[0].IDTeacher).Timetable);
                }
                else
                {
                    MessageBox.Show("Đổi thất bại");
                }
            }
            else
            {
                int index = (swap[0].Y * 7) + swap[0].X;
                tlp.Controls[index].BackColor = SystemColors.Control;
            }

            RemoveHighlight(tlp);
        }
        #endregion



        private void LoadTimeTableTeacher(int[][] TT)  // tạo ô thời khóa biểu lớp
        {
            
            tlpGiaoVien.Controls.Clear();
            Matrix = new List<List<Button>>();

            for (int i = 0; i < 10; i++)
            {
                Matrix.Add(new List<Button>());

                for (int j = 0; j < 7; j++)
                {
                    var btn = new Button
                    {
                        Dock = DockStyle.Fill,
                        Font = new Font("Time New Roman", 14f, FontStyle.Bold),
                        Text = GetNameClass(TT[j][i]),
                        Margin = new Padding(0),
                        Padding = new Padding(0),
                        BackColor = SystemColors.Control,
                        Tag = new SPTag(cbxGiaoVien.SelectedIndex + 1, STeacher.IDSubject, TT[j][i], j, i)
                    };
                    btn.Click += BtnTGV_Click;
                    tlpGiaoVien.Controls.Add(btn);
                    Matrix[i].Add(btn);

                }
            }

        }

        // Thay doi theo ngoài lớp
        #region Thay doi mon cho GV

        private void BtnTGV_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            SPTag t = btn.Tag as SPTag;

            if (t.IDClass == -1)
            {
                int IDSub = Program.SClass.TimetableClass[t.X][t.Y];
                TSwap.Add(new SPTag(lstT.FirstOrDefault(p=>p.IDSub == IDSub).IDTeacher, IDSub, Program.SClass.ID, t.X, t.Y));
            }
            else
            {
                Teacher teacher = Program.lstTeacher.FirstOrDefault(p => p.ID == t.IDTeacher);
                btn.BackColor = Color.Red;
                TSwap.Add(t);
            }
            

            switch (TSwap.Count)
            {
                case 1:
                    {
                        Program.SClass = Program.lstClasses.FirstOrDefault(c => c.ID == t.IDClass);
                        lstT = new List<TimeTableTeacher>();
                        lstT = new TimeTable().GetTimeTableTeachers(Program.SClass.listTeacher, Program.lstTeacher);
                        LoadTimeTable(Program.SClass.TimetableClass);
                        Find(Program.lstGrades.FirstOrDefault(g => g.ID == Program.SClass.IDGrade).Morning, Program.lstSubjects.FirstOrDefault(s => s.ID == TSwap[0].IDSub).SubMain, tlpGiaoVien, TSwap);
                        break;
                    }
                case 2:
                    {
                        HandleSwap(TSwap, tlpGiaoVien);
                        TSwap = new List<SPTag>();
                        break;
                    }
                default:
                    break;
            }
        }

        #endregion

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

        //Select GV
        private void cbxGiaoVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbx = sender as ComboBox;

            string str = cbx.SelectedItem as string;
            str = str.Remove(0, str.LastIndexOf("-") + 2);

            STeacher = Program.lstTeacher.FirstOrDefault(p => p.ID == Convert.ToInt32(str));

            lblMon.Text = "Thời khóa biểu giáo viên " + Program.lstSubjects.FirstOrDefault(p=>p.ID == STeacher.IDSubject).Name;


            LoadTimeTableTeacher(STeacher.Timetable);
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

    public class SPTag
    {

        public int IDTeacher { get; set; }
        public int IDSub { get; set; }
        public int IDClass { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public SPTag() { }

        public SPTag(int iDTeacher, int iDSub, int iDClass, int x, int y)
        {
            IDTeacher = iDTeacher;
            IDSub = iDSub;
            IDClass = iDClass;
            X = x;
            Y = y;
        }
    }
}
