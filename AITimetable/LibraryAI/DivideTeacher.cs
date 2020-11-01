using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAI
{
    public class DivideTeacher
    {
        // chua cho gv 1 mon
        private void DivideSubTeacher(List<Teacher> teachers, List<Class> classes)
        {
            int Min = (int) (classes.Count / teachers.Count);
            int t = classes.Count % teachers.Count;
            int[] countClassOfTeacher = new int[teachers.Count];

            for (int i = 0; i < teachers.Count; i++)
            {
                if (t != 0)
                {
                    countClassOfTeacher[i] = Min + 1;
                    t--;
                }
                else
                {
                    countClassOfTeacher[i] = Min;
                }
            }

            int loop = 0;
            foreach (var i in classes)
            {
                if (countClassOfTeacher[loop] == 0)
                {
                    loop++;
                }

                i.listTeacher.Add(teachers[loop].ID);
                countClassOfTeacher[loop]--;
            }
        }


        // Chia giáo viên toàn bộ các môn
        public void Handle(List<List<Teacher>> teachers, List<Class> classes)
        {
            for (int i = 0; i < teachers.Count; i++)
            {
                DivideSubTeacher(teachers[i], classes);
            }
        }
    }
}
