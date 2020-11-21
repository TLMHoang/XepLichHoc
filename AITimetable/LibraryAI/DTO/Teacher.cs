using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryAI
{
    public class Teacher
    {
        

        public int ID { get; set; }
        public string Name { get; set; }
        public int IDSubject { get; set; }
        public List<int> Class { get; set; }
        public int[][] Timetable { get; set; }

        public Teacher() { }

        public Teacher(int iD, string name, int iDSubject, int[][] timetable)
        {
            ID = iD;
            Name = name;
            IDSubject = iDSubject;
            Timetable = timetable;
        }

        public Teacher(int iD, string name, int iDSubject)
        {
            ID = iD;
            Name = name;
            IDSubject = iDSubject;
            Timetable = new int[7][];
            Class = new List<int>();
            for (int i = 0; i < Timetable.Length; i++)
            {
                Timetable[i] = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            }
        }

        // Tạo dữ liệu test gv
        public List<Teacher> CreateDataTeacher(List<Subjects> lstSubjects)
        {
            int count = 0;
            Random rad = new Random();
            NameTeacher nteacher = new NameTeacher();
            List<Teacher> lstTeachers = new List<Teacher>();

            foreach (var s in lstSubjects)
            {
                switch (s.ID)
                {
                    case 11:
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                lstTeachers.Add(new Teacher(count, (nteacher.FirstName[rad.Next(0, 5)]+ " " + nteacher.LastName[rad.Next(0, 21)]), s.ID));
                                count++;
                            }
                            
                            break;
                        }
                    case 12:
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                lstTeachers.Add(new Teacher(count, (nteacher.FirstName[rad.Next(0, 5)]+ " " + nteacher.LastName[rad.Next(0, 21)]), s.ID));
                                count++;
                            }
                            break;
                        }
                    default:
                        {
                            for (int i = 0; i < s.TimesOnWeek; i++)
                            {
                                lstTeachers.Add(new Teacher(count, (nteacher.FirstName[rad.Next(0, 5)]+ " " + nteacher.LastName[rad.Next(0, 21)]), s.ID));
                                count++;
                            }
                            break;
                        }
                }
            }

            return lstTeachers;
        }


        // tạo data theo nhóm sub
        public List<List<Teacher>> CreateDataTestDT(List<Subjects> lstSubjects, List<Teacher> lstTeachers)
        {
            List<List<Teacher>> lst = new List<List<Teacher>>();

            foreach (var s in lstSubjects)
            {
                lst.Add(lstTeachers.Where(t=>t.IDSubject == s.ID).ToList());
            }

            return lst;
        }
    }

    class NameTeacher
    {
        public string[] FirstName { get; set; }
        public string[] LastName { get; set; }

        public NameTeacher()
        {
            FirstName = new string[]
            {
                "Trần",
                "Lê",
                "Nguyễn",
                "Phạm",
                "Lý",
                "Lưu"
            };
            LastName = new string[]
            {
                "Minh",
                "Hoàng",
                "Ly",
                "Linh",
                "Lý",
                "Ánh",
                "Lê",
                "Anh",
                "Mạnh",
                "Quỳnh",
                "Hiếu",
                "Hiểu",
                "Yến",
                "Uyên",
                "Châu",
                "Thủy",
                "Hằng",
                "Oanh",
                "Thịnh",
                "Thăng",
                "Nhi"
            };
        }
    }
}
