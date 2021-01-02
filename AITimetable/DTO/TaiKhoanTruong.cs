namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    [Table("nxtckedu_sa.TaiKhoanTruong")]
    public partial class TaiKhoanTruong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        private DBContext db = new DBContext();

        public TaiKhoanTruong()
        {
            PhanCongDays = new HashSet<PhanCongDay>();
            PhanCongDays1 = new HashSet<PhanCongDay>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string TaiKhoan { get; set; }

        [StringLength(500)]
        public string MatKhau { get; set; }

        public bool? Loai { get; set; }

        [StringLength(200)]
        public string TenGV { get; set; }

        [StringLength(12)]
        public string SDT { get; set; }

        public int? IDMonHoc { get; set; }

        public int? IDLop { get; set; }

        public bool? TrangThai { get; set; }

        public virtual Lop Lop { get; set; }

        public virtual MonHoc MonHoc { get; set; }

        public virtual MonHoc MonHoc1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanCongDay> PhanCongDays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanCongDay> PhanCongDays1 { get; set; }


        public TaiKhoanTruong(int iD, string taiKhoan, string matKhau, bool? loai, string tenGV, string sDT, int? iDMonHoc, int? iDLop, bool? trangThai)
        {
            ID = iD;
            TaiKhoan = taiKhoan;
            MatKhau = matKhau;
            Loai = loai;
            TenGV = tenGV;
            SDT = sDT;
            IDMonHoc = iDMonHoc;
            IDLop = iDLop;
            TrangThai = trangThai;
        }


        public async Task<TaiKhoanTruong> DangNhap(string TaiKhoan, string MatKhau)
        {
            List<TaiKhoanTruong> tk = await (db.Database.SqlQuery<TaiKhoanTruong>("exec DangNhapTruong",
                new SqlParameter("@TaiKhoan", System.Data.SqlDbType.VarChar) { Value = TaiKhoan },
                new SqlParameter("@MatKhau", System.Data.SqlDbType.VarChar) { Value = MatKhau })).ToListAsync();


            return (tk.Count == 1) ? tk[0] : null;
        }
    }
}
