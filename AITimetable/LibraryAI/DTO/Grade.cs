using System;
using System.Collections.Generic;

namespace LibraryAI
{
    public class Grade
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Morning { get; set; }
        public List<Subjects> Target { get; set; }
        public List<Class> listClassInGrade { get; set; }

        public Grade() { }

        public Grade(int iD, string name, bool morning, string sCode, int amountClass, int start)
        {
            int count = start;
            ID = iD;
            Name = name;
            Morning = morning;
            Target = new Subjects().CreateDataTest();

            listClassInGrade = new Class().createDataTest(iD, morning, name, sCode, start, start + 5);

        }

        // Tạo dữ liệu test trướng khi liên kết với database
        public List<Grade> CreateDataTest()
        {
            List<Grade> lst = new List<Grade>();

            lst.Add(new Grade(1, "10", true, "A", 5, 0));
            lst.Add(new Grade(2, "11", false, "B", 5, 5));
            lst.Add(new Grade(3, "12", false, "C", 5, 10));

            return lst;
        }
    }
}
