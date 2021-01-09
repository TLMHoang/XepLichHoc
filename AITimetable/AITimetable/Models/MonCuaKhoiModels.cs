using AITimetable.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITimetable.Models
{
    public class MonCuaKhoiModels
    {
        private DBContext db = new DBContext();

        public List<MonHoc> GetMonHoc(int iDKhoi)
        {
            List<MonHoc> monHocs = new List<MonHoc>();

            var lst = db.MonCuaKhois.Where(p => p.IDKhoi == iDKhoi);


            foreach (var i in lst)
            {
                monHocs.Add(i.MonHoc);
            }

            return monHocs;
        }
    }
}
