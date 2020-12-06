using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryAI
{
    public class TimeTable
    {
        private List<int> lstIDClass = new List<int>();
        private List<int> lstIDTeacherOfClass = new List<int>();
        private Class CSelect = new Class();
        private List<CountLesson> lstCount;

        public void XepLich(List<Class> classes, List<Teacher> teachers, List<Subjects> subjects)
        {
            lstCount = new CountLesson().getList(subjects);
            GetClassNoTimeTable(classes);
            while (lstIDClass.Count != 0)
            {
                SetTimeTimeTableForclass(classes, teachers, subjects);
            }
        }

        //xếp thời khóa biểu cho 1 lớp
        private void SetTimeTimeTableForclass(List<Class> classes, List<Teacher> teachers, List<Subjects> subjects)
        {
            lstCount = new CountLesson().getList(subjects);
            SelectRandomClass(classes);
            SetDefaultSub();
            int SubStart = GetSubFirstInWeek(subjects, teachers);

            Teacher sTeacher = teachers.FirstOrDefault(p => p.ID == lstIDTeacherOfClass[SubStart]);
            Subjects sSubject = subjects.FirstOrDefault(s => s.ID == sTeacher.IDSubject);

            HandleWithMSub(sTeacher, sSubject, (sSubject.SubMain) ? 0 : -1);
            lstIDTeacherOfClass.RemoveAt(SubStart);
            lstIDTeacherOfClass.Add(sTeacher.ID);


            for (int i = 0; i < lstIDTeacherOfClass.Count - 1; i++)
            {
                sTeacher = teachers.FirstOrDefault(p => p.ID == lstIDTeacherOfClass[i]);
                sSubject = subjects.FirstOrDefault(s => s.ID == sTeacher.IDSubject);

                HandleWithMSub(sTeacher, sSubject, (sSubject.SubMain) ? 0 : -1);
            }
            #region Dùng sau
            /*
            while (lstIDTeacherOfClass.Count != 0)
            {
                sTeacher = teachers.FirstOrDefault(p => p.ID == lstIDTeacherOfClass[0]);
                sSubject = subjects.FirstOrDefault(s => s.ID == sTeacher.IDSubject);

                HandleWithMSub(sTeacher, sSubject, (sSubject.SubMain) ? 0 : -1);
                lstIDTeacherOfClass.RemoveAt(0);
                //if (sSubject.SubMain)
                //{
                //    HandleWithMSub(sTeacher, sSubject, (sSubject.SubMain) ? 0 : -1);
                //    lstIDTeacherOfClass.RemoveAt(0);

                //}
                //else
                //{
                //    if (lstIDTeacherOfClass.Count <= 2)
                //    {
                //        if (sSubject.Name.Equals("Thể giục"))
                //        {

                //        }
                //    }
                //    else
                //    {
                //        lstIDTeacherOfClass.Add(lstIDTeacherOfClass[0]);
                //        lstIDTeacherOfClass.RemoveAt(0);
                //    }
                //}
                
            }

            //foreach (int i in lstIDTeacherOfClass)
            //{
            //    sTeacher = teachers.FirstOrDefault(p => p.ID ==i);
            //    sSubject = subjects.FirstOrDefault(s => s.ID == sTeacher.IDSubject);

            //    HandleWithMSub(sTeacher, sSubject, (sSubject.SubMain) ? 0 : -1);
            //}
            */
            #endregion

            List<ExchangeLesson> lstEx = CheckTKB(CSelect.TimetableClass);
            if (lstEx.Count > 0)
            {
                FixTimeTable(lstEx, lstCount, lstIDTeacherOfClass, teachers);
            }
            //CSelect.Error = (.Count > 0) ? true : false;
        }

        //Lấy danh sách các class chưa có THời khóa biểu
        private void GetClassNoTimeTable(List<Class> classes)
        {
            foreach (Class c in classes)
            {
                lstIDClass.Add(c.ID);
            }
        }

        //đặt môn mặc định (Chào cờ SHLop)
        private void SetDefaultSub(/*int CC, int SHL*/)
        {
            if (CSelect.TimetableClass[0][0] == -1)
            {
                CSelect.TimetableClass[0][9] = -99;
                CSelect.TimetableClass[5][5] = -98;

            }
            else
            {
                CSelect.TimetableClass[0][0] = -99;
                CSelect.TimetableClass[5][0] = -98;
            }

        }


        //Chọn lớp để xếp

        private void SelectRandomClass(List<Class> classes)
        {
            Random rand = new Random();
            CSelect = new Class();
            int iSe = rand.Next(0, lstIDClass.Count - 1);
            CSelect = classes.FirstOrDefault(p => p.ID == lstIDClass[iSe]);

            lstIDTeacherOfClass = new List<int>();
            foreach (int i in CSelect.listTeacher)
            {
                lstIDTeacherOfClass.Add(i);
            }

            lstIDClass.RemoveAt(iSe);
        }

        // Lấy danh sách giáp viên



        //Xep mon hoc buoi phụ
        private void HandleWithSub(Subjects TD, Subjects GDQP)
        {
        }

        #region thay dổi môn học. cho tkb bị rong môn

        // Chuyển các môn cho TKB hoàn chỉnh
        private void FixTimeTable(List<ExchangeLesson> lstEx, List<CountLesson> lstC, List<int> lstIdTecher, List<Teacher> lstTeacher)
        {
            List<int> lstSB = GetSubFail(lstC);
            List<TimeTableTeacher> lstTTT = GetTimeTableTeachers(lstIdTecher, lstTeacher);
            CountLesson c = new CountLesson();


            while (lstSB.Count > 0)
            {
                int countLeft = lstC.FirstOrDefault(p => p.IDSub == lstSB[0]).MaxTimes - lstC.FirstOrDefault(p => p.IDSub == lstSB[0]).Times;

                TimeTableTeacher STTT = lstTTT.FirstOrDefault(p => p.IDSub == lstSB[0]);

                TimeTableTeacher SN = ChangeSub(STTT, GetTimeTableTeachers(lstIdTecher, lstTeacher), lstEx[0]);

                if (SN != null)
                {
                    lstEx.RemoveAt(0);
                    lstTeacher.FirstOrDefault(t => t.ID == STTT.IDTeacher).Timetable = STTT.TT;
                    lstTeacher.FirstOrDefault(t => t.ID == SN.IDTeacher).Timetable = SN.TT;
                }

                c = lstC.FirstOrDefault(p => p.IDSub == lstSB[0]);

                if (c.MaxTimes == c.Times)
                {
                    lstSB.RemoveAt(0);
                }
            }
        }

        // Tìm mon có thể thay thế
        private TimeTableTeacher ChangeSub(TimeTableTeacher teacher, List<TimeTableTeacher> lstTeachers, ExchangeLesson exchange)
        {
            List<ExchangeLesson> lst = new List<ExchangeLesson>();
            foreach (TimeTableTeacher item in lstTeachers)
            {
                if (item.IDTeacher != teacher.IDTeacher)
                {
                    if (item.TT[exchange.X][exchange.Y] == -1)
                    {
                        for (int i = 0; i < CSelect.TimetableClass.Length - 1; i++)
                        {
                            for (int j = 0; j < CSelect.TimetableClass[i].Length; j++)
                            {
                                if (CSelect.TimetableClass[i][j] == item.IDSub)
                                {
                                    lst.Add(new ExchangeLesson(item.IDTeacher, i, j));
                                }
                            }
                        }

                        foreach (ExchangeLesson e in lst)
                        {
                            if (teacher.TT[e.X][e.Y] == -1)
                            {
                                item.TT[exchange.X][exchange.Y] = CSelect.ID;
                                CSelect.TimetableClass[exchange.X][exchange.Y] = item.IDSub;
                                teacher.TT[e.X][e.Y] = CSelect.ID;
                                CSelect.TimetableClass[e.X][e.Y] = teacher.IDSub;
                                lstCount.FirstOrDefault(c => c.IDSub == teacher.IDSub).Times++;
                                return item;
                            }
                        }
                    }
                }
            }

            return null;
        }


        // LẤy các mon chưa đủ tiết
        private List<int> GetSubFail(List<CountLesson> lstC)
        {
            List<int> lst = new List<int>();

            foreach (CountLesson item in lstC)
            {

                if (item.MaxTimes != item.Times)
                {
                    lst.Add(item.IDSub);
                }
            }

            return lst;
        }

        // Lấy toàn bộ thời khóa biểu của giáo viên
        public List<TimeTableTeacher> GetTimeTableTeachers(List<int> lstIdTeacher, List<Teacher> lstTeacher)
        {
            List<TimeTableTeacher> lst = new List<TimeTableTeacher>();

            foreach (int item in lstIdTeacher)
            {
                Teacher t = lstTeacher.FirstOrDefault(p => p.ID == item);
                lst.Add(new TimeTableTeacher(item, t.IDSubject, t.Timetable));
            }

            return lst;
        }

        #endregion

        // Xếp Mon hoc buoi chinh
        private void HandleWithMSub(Teacher teacher, Subjects subject, int iDefault)
        {
            int countSub = 0;
            //int INull = 0;
            for (int i = 0; i < CSelect.TimetableClass.Length - 1; i++)
            {
                for (int j = 0; j < CSelect.TimetableClass[i].Length; j++)
                {
                    if (CSelect.TimetableClass[i][j] == iDefault) // Kiem tra xem TKB lop co rong tai vi ti i, j
                    {
                        if (teacher.Timetable[i][j] == -1)// Kiem tra xem TKB GV co rong tai vi ti i, j
                        {
                            teacher.Timetable[i][j] = CSelect.ID;
                            CSelect.TimetableClass[i][j] = teacher.IDSubject;
                            countSub++;
                            if (subject.MaxInDay == 2 && countSub < subject.TimesOnWeek) // Them 1 tiết bên dưới nêu còn tiết và giới han tiet tren ngay là 2 tro len
                            {
                                int x = j + 1;
                                if (x >= 10)
                                {
                                    //INull = LoopWeek(i);
                                    i++;
                                }
                                else
                                {
                                    if (CSelect.TimetableClass[i][x] == iDefault && teacher.Timetable[i][x] == 0)
                                    {
                                        teacher.Timetable[i][x] = CSelect.ID;
                                        CSelect.TimetableClass[i][x] = teacher.IDSubject;
                                        countSub++;
                                    }
                                    //INull = LoopWeek(i);
                                    i++;
                                }
                            }

                            break;
                        }
                    }
                }
                if (subject.TimesOnWeek <= countSub)
                {
                    break;
                }
            }
            #region Chưa dùng
            // xếp tiếp tiết nếu còn


            //if (subject.TimesOnWeek > countSub)
            //{
            //    for (int i = 0; i < CSelect.TimetableClass[INull].Length; i++)
            //    {
            //        if (CSelect.TimetableClass[INull][i] == iDefault)
            //        {
            //            if (teacher.Timetable[INull][i] == 0)
            //            {
            //                teacher.Timetable[INull][i] = CSelect.ID;
            //                CSelect.TimetableClass[INull][i] = teacher.IDSubject;
            //                countSub++;
            //                if (subject.MaxInDay == 2 && countSub < subject.TimesOnWeek) // Kiểm tra xem mon này có 2 tiết 1 ngày ko + full tiết trong tuần chưa
            //                {
            //                    int x = i + 1;
            //                    if (x < 10)
            //                    {
            //                        if (CSelect.TimetableClass[INull][x] == iDefault && teacher.Timetable[INull][x] == 0)
            //                        {
            //                            teacher.Timetable[INull][x] = CSelect.ID;
            //                            CSelect.TimetableClass[INull][x] = teacher.IDSubject;
            //                            countSub++;
            //                        }
            //                    }
            //                }
            //                break;
            //            }
            //        }
            //    }
            //}
            #endregion

            //Fix nốt môn thiếu vào tkb
            if (countSub < subject.TimesOnWeek)
            {
                for (int i = 0; i < CSelect.TimetableClass.Length - 1; i++)
                {
                    for (int j = 0; j < CSelect.TimetableClass[i].Length; j++)
                    {
                        if (CSelect.TimetableClass[i][j] == iDefault)
                        {
                            if (teacher.Timetable[i][j] == -1)
                            {
                                teacher.Timetable[i][j] = CSelect.ID;
                                CSelect.TimetableClass[i][j] = teacher.IDSubject;
                                countSub++;
                                if (countSub >= subject.TimesOnWeek)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    if (countSub >= subject.TimesOnWeek)
                    {
                        break;
                    }
                }
            }



        }

        // Check fail TKB
        // Kiểm tra vị trí bị rỗng
        // Dếm lại môn đã xuất hiện trong TKB
        public List<ExchangeLesson> CheckTKB(int[][] tb)
        {
            List<ExchangeLesson> lst = new List<ExchangeLesson>();
            
            for (int i = 0; i < tb.Length - 1; i++)
            {
                CountLesson a;
                for (int j = 0; j < tb[i].Length; j++)
                {
                    if (tb[i][j] == 0)
                    {
                        lst.Add(new ExchangeLesson(-1, i, j));
                    }
                    else
                    {
                        // Đếm số lượng của các môn
                        a = lstCount.FirstOrDefault(p => p.IDSub == tb[i][j]);
                        if (a != null)
                        {
                            a.Times++;
                        }
                    }

                }
            }


            return lst;
        }

        // đặt biến dếm bằng 0
        public void ResetTimes()
        {
            foreach (CountLesson item in lstCount)
            {
                item.Times = 0;
            }
        }


        // Tăng biến đếm lên 1


        //Loop week
        private int LoopWeek(int j)
        {
            if (j < 5)
            {
                return j + 1;
            }
            else
            {
                return 0;
            }
        }
        

        //Lấy môn dầu tiên hoc của lớp
        public int GetSubFirstInWeek(List<Subjects> subjects, List<Teacher> teachers)
        {
            foreach (int i in lstIDTeacherOfClass)
            {
                Teacher t = teachers.FirstOrDefault(p => p.ID == i);
                Subjects s = subjects.FirstOrDefault(p => p.ID == t.IDSubject);
                if (s.SubMain)
                {
                    if (CSelect.TimetableClass[0][0] == -1)
                    {
                        if (teachers[i].Timetable[5][0] == 0)
                        {
                            return i;
                        }
                    }
                    else
                    {
                        if (teachers[i].Timetable[0][1] == 0)
                        {
                            return i;
                        }
                    }
                }
            }
            return 0;
        }
    }
}
