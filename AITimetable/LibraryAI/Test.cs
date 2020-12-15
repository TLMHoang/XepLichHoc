using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryAI
{
    public class Test
    {
        public int IDClass { get; set; }
        public int IDTeacher { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Test()
        {
        }

        public Test(int iDClass, int iDTeacher, int x, int y)
        {
            IDClass = iDClass;
            IDTeacher = iDTeacher;
            X = x;
            Y = y;
        }

        public List<Test> Check(List<Class> classes, List<Teacher> teachers, List<Subjects> subjects)
        {
            List<Test> tests = new List<Test>();
            foreach (Class c in classes)
            {
                List<TimeTableTeacher> timeTableTeachers = new TimeTable().GetTimeTableTeachers(c.listTeacher, teachers);

                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (c.TimetableClass[i][j] != 0 && c.TimetableClass[i][j] != -1 && c.TimetableClass[i][j] != -99 && c.TimetableClass[i][j] != -98)
                        {
                            TimeTableTeacher t = timeTableTeachers.FirstOrDefault(p => p.IDSub == c.TimetableClass[i][j]);
                            if (t.TT[i][j] != c.ID)
                            {
                                tests.Add(new Test(c.ID, t.IDTeacher, i, j));
                            }
                        }
                    }
                }
            }


            return tests;
        }
    }
}
