using AITimetable.Database;
using LibraryAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AITimetable
{
    static class Program
    {
        public static List<Subjects> lstSubjects = new Subjects().CreateDataTest();
        public static List<Teacher> lstTeacher;
        public static List<Grade> lstGrades = new Grade().CreateDataTest();
        public static List<List<Teacher>> aLstTeachers;
        public static List<Class> lstClasses;
        public static Class SClass = new Class();
        public static MonCuaKhoi monCuaKhoi = new MonCuaKhoi();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
