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

namespace AITimetable
{
    public partial class frmMain : Form
    {
        List<Subjects> lstSubjects = new Subjects().CreateDataTest();
        List<Teacher> lstTeacher;
        List<Grade> lstGrades = new Grade().CreateDataTest();
        List<List<Teacher>> aLstTeachers;
        List<Class> lstClasses;
        public frmMain()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;

            lstTeacher = new Teacher().CreateDataTeacher(lstSubjects);
            aLstTeachers = new Teacher().CreateDataTestDT(lstSubjects, lstTeacher);
            lstClasses = new Class().createDataTest(lstGrades);
        }

        private void btnChiaGiaoVien_Click(object sender, EventArgs e)
        {
            new DivideTeacher().Handle(aLstTeachers, lstClasses);

            Task.Run(() =>
            {
                foreach (var c in lstClasses)
                {
                    rtxtData.Text += c.Name + "\n";
                    foreach (var t in c.listTeacher)
                    {
                        Teacher nT = lstTeacher.FirstOrDefault(p => p.ID == t);
                        PrintText(nT.Name, lstSubjects.FirstOrDefault(p => p.ID == nT.IDSubject).Name);
                        //rtxtData.Text += nT.Name + "\t" + lstSubjects.FirstOrDefault(p => p.ID == nT.IDSubject).Name + "\n";
                    }
                    rtxtData.Text += "\n\n\n\n\n";
                }
            });
        }

        private void PrintText(string name, string sName)
        {
            rtxtData.Text += name;

            int loop = 40 - name.Length;
            string valSTR = "";
            for (int i = 0; i < loop; i++)
            {
                valSTR += " ";
            }
            rtxtData.Text += valSTR + sName + "\n";
        }
    }
}
