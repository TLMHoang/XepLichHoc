using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryAI
{
    public class Class
    {
        public int ID { get; set; }
        public int IDGrade { get; set; }
        public string Name { get; set; }
        public int[][] TimetableClass { get; set; }
        public List<int> listTeacher { get; set; }


        public Class()
        {
        }

        //Khởi tạo thời khóa biểu phân biệt buổi chính + phụ
        public Class(int iD, Grade grade, string nameClass)
        {
            ID = iD;
            IDGrade = grade.ID;
            Name = grade.Name + nameClass;
            listTeacher = new List<int>();

            SetTimetable(7, 10, grade.Morning);

            
        }

        public Class(int iD, int iDGrade, bool morning, string nameGrade, string nameClass)
        {
            ID = iD;
            IDGrade = iDGrade;
            Name = nameGrade + nameClass;
            listTeacher = new List<int>();

            SetTimetable(7, 10, morning);

        }

        //Function create TimetableClass
        public void SetTimetable(int Days, int Tiet, bool morning)
        {
            TimetableClass = new int[Days][];
            for (int i = 0; i < Days; i++)
            {
                TimetableClass[i] = new int[Tiet];
            }

            if (morning)
            {
                for (int i = 0; i < TimetableClass.Length; i++)
                {
                    for (int j = 5; j < 10; j++)
                    {
                        TimetableClass[i][j] = -1;
                    }
                }
            }
            else
            {
                for (int i = 0; i < TimetableClass.Length; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        TimetableClass[i][j] = -1;
                    }
                }
            }
        }

        // tạo dữ liệu test
        public List<Class> createDataTest(int iDGrade, bool morning, string nameGrade, string nameClass, int start, int end)
        {
            List<Class> lst = new List<Class>();

            for (int i = start; i < end; i++)
            {
                lst.Add(new Class(i, iDGrade, morning, nameGrade, nameClass + (i - start + 1)));
            }

            return lst;
        }

        public List<Class> createDataTest(List<Grade> grades)
        {
            List<Class> lst = new List<Class>();

            foreach (var i in grades)
            {
                lst = lst.Concat(i.listClassInGrade).ToList();
            }

            return lst;
        }


        //Khởi tạo thời khóa biểu phân biệt buổi chính + phụ
        //public Class(int iD, Grade grade, string nameClass, int Days, int Tiet)
        //{
        //    ID = iD;
        //    IDGrade = grade.ID;
        //    Name = grade.Name + nameClass;

        //    SetTimetable(Days, Tiet);

        //    if (grade.Morning)
        //    {
        //        for (int i = 0; i < TimetableClass.Length; i++)
        //        {
        //            int End = (int)TimetableClass[i].Length / 2;
        //        }
        //    }
        //}
    }


}
