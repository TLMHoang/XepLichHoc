using AITimetable.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITimetable.Models
{
    public class TaiKhoanModels
    {
        private DBContext db = new DBContext();

        public TaiKhoanTruong DangNhap(string TaiKhoan, string MatKhau)
        {
            var lst = db.Database.SqlQuery<TaiKhoanTruong>("exec DangNhapTruong @TaiKhoan, @MatKhau",
                new SqlParameter("@TaiKhoan", System.Data.SqlDbType.VarChar) { Value = TaiKhoan },
                new SqlParameter("@MatKhau", System.Data.SqlDbType.VarChar) { Value = MatKhau }).ToList();

            return (lst.Count == 1) ? lst[0] : null;
        }

    }
}
