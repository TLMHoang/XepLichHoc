using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAI
{
    public class Subjects
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TimesOnWeek { get; set; }
        public bool SubMain { get; set; }
        public int MaxInDay { get; set; }
        public bool subMain { get; set; }

        public Subjects() { }

        public Subjects(int iD, string nameSub, int times, bool subMain)
        {
            ID = iD;
            Name = nameSub;
            TimesOnWeek = times;
            SubMain = subMain;
            MaxInDay = 2;
        }

        // Tạo dữ liệu test trướng khi liên kết với database
        public List<Subjects> CreateDataTest()
        {
            List<Subjects> lst = new List<Subjects>();

            lst.Add(new Subjects(1, "Toán", 4, true));// 4
            lst.Add(new Subjects(2, "Lý", 3, true));// 3
            lst.Add(new Subjects(3, "Hóa", 3, true)); // 3
            lst.Add(new Subjects(4, "Sinh", 2, true)); // 2
            lst.Add(new Subjects(5, "Sử", 2, true));// 2 
            lst.Add(new Subjects(6, "Địa", 2, true));// 2
            lst.Add(new Subjects(7, "Văn", 4, true));// 4 
            lst.Add(new Subjects(8, "Anh", 4, true));// 4
            lst.Add(new Subjects(9, "Công Nghệ", 2, true));// 2
            lst.Add(new Subjects(10, "GDCD", 2, true));// 2
            lst.Add(new Subjects(11, "Thể giục", 2, false));//4
            lst.Add(new Subjects(12, "GDQP", 1, false));//2

            return lst;
        }
    }
}
