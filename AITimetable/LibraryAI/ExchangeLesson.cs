using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAI
{
    public class ExchangeLesson
    {
        public int IDTeacher { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public ExchangeLesson()
        {
        }

        public ExchangeLesson(int iDTeacher, int x, int y)
        {
            IDTeacher = iDTeacher;
            X = x;
            Y = y;
        }
    }

    public class CountLesson
    {
       

        public int IDSub { get; set; }
        public int Times { get; set; }
        public int MaxTimes { get; set; }


        public CountLesson()
        {
        }

        public CountLesson(int iDSub, int times, int maxTimes)
        {
            IDSub = iDSub;
            Times = times;
            MaxTimes = maxTimes;
        }

        public CountLesson(Subjects subjects)
        {
            IDSub = subjects.ID;
            Times = 0;
            MaxTimes = subjects.TimesOnWeek;
        }

        public List<CountLesson> getList(List<Subjects> lstSub)
        {
            List<CountLesson> lst = new List<CountLesson>();
            foreach (Subjects item in lstSub)
            {
                lst.Add(new CountLesson(item));
            }

            return lst;
        }


        
    }


    public class TimeTableTeacher
    {
        

        public int IDTeacher { get; set; }
        public int IDSub { get; set; }
        public int[][] TT { get; set; }

        public TimeTableTeacher()
        {
            
        }

        public TimeTableTeacher(int iDTeacher, int iDSub, int[][] tT)
        {
            IDTeacher = iDTeacher;
            IDSub = iDSub;
            TT = tT;
        }
    }
}
