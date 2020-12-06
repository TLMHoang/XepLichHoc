using LibraryAI;
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
    public partial class frmChangeSub : Form
    {
        private List<TimeTableTeacher> lstT;
        private List<int> lstbtn = new List<int>();
        private List<SPTag> lstTag = new List<SPTag>();
        private List<SPTag> Swap = new List<SPTag>();


        public frmChangeSub()
        {
            InitializeComponent();
        }

        private List<List<Button>> matrix;

        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }

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

        private void LoadTimeTableTeacher(int[][] TT, TableLayoutPanel tlp)  // tạo ô thời khóa biểu lớp
        {
            tlp.Controls.Clear();
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
                        BackColor = SystemColors.Control
                    };
                    tlp.Controls.Add(btn);
                    Matrix[i].Add(btn);

                }
            }

        }

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
            else
            {
                int[][] iArr = new int[7][];
                for (int i = 0; i < 7; i++)
                {
                    iArr[i] = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                }
            }

            Find();

            if (Swap.Count == 2)
            {
                foreach (SPTag sP in Swap)
                {
                    int index = (sP.Y * 7) + sP.X;
                    Button b = tlpTKB.Controls[index] as Button;
                    b.BackColor = SystemColors.Control;
                }

                if (SwapSub())
                {

                }
                else
                {
                    MessageBox.Show("Đổi thất bại");
                }


                Swap = new List<SPTag>();
                RemoveHighlight();
            }
        }

        private bool SwapSub()
        {
            SPTag SWS = Swap[0];
            TimeTableTeacher ST = lstT.FirstOrDefault(t => t.IDTeacher == SWS.IDTeacher);
            SPTag SWT = Swap[1];
            TimeTableTeacher TT = lstT.FirstOrDefault(t => t.IDTeacher == SWT.IDTeacher);

            if (SWS.X != SWT.X || SWS.Y != SWT.Y)
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

                var aVal = Program.lstClasses;
                LoadTimeTable(Program.SClass.TimetableClass);

            }

            return true;
            
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

        private void frmChangeSub_Load(object sender, EventArgs e)
        {
            lstT = new TimeTable().GetTimeTableTeachers(Program.SClass.listTeacher, Program.lstTeacher);
            LoadTimeTable(Program.SClass.TimetableClass);
        }

        private void RemoveHighlight()
        {
            foreach (int i in lstbtn)
            {
                (tlpTKB.Controls[i] as Button).BackColor = SystemColors.Control;
            }
        }

        private void Find()
        {
            if (Swap.Count == 1)
            {
                foreach (TimeTableTeacher item in lstT)
                {
                    List<ExchangeLesson> lst = new List<ExchangeLesson>();
                    if (item.IDTeacher != Swap[0].IDTeacher) // Kiem tra xem phai mon dang doi hay ko
                    {
                        //ktra gv co trong lich tai cai vi tri dang muon doi
                        if (item.TT[Swap[0].X][Swap[0].Y] == -1)
                        {
                            for (int i = 0; i < Program.SClass.TimetableClass.Length - 1; i++)
                            {
                                for (int j = 0; j < Program.SClass.TimetableClass[i].Length; j++)
                                {
                                    if (Program.SClass.TimetableClass[i][j] == item.IDSub)
                                    {
                                        lst.Add(new ExchangeLesson(item.IDTeacher, i, j));
                                    }
                                }
                            }

                            foreach (ExchangeLesson e in lst)
                            {
                                TimeTableTeacher sTeacher = lstT.FirstOrDefault(t => t.IDTeacher == Swap[0].IDTeacher);
                                if (sTeacher.TT[e.X][e.Y] == -1)
                                {
                                    int index = (e.Y * 7) + e.X;
                                    Button btn = tlpTKB.Controls[index] as Button;
                                    lstbtn.Add(index);
                                    btn.BackColor = Color.LightYellow;
                                }
                            }
                        }
                    }
                }
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


        public SPTag(){}

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
