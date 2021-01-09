namespace AITimetable.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<BangDiem> BangDiems { get; set; }
        public virtual DbSet<BHYT> BHYTs { get; set; }
        public virtual DbSet<CupHoc> CupHocs { get; set; }
        public virtual DbSet<DiemDanh> DiemDanhs { get; set; }
        public virtual DbSet<DTBMon> DTBMons { get; set; }
        public virtual DbSet<DTBTong> DTBTongs { get; set; }
        public virtual DbSet<FunctionOrder> FunctionOrders { get; set; }
        public virtual DbSet<HoaDonHocPhi> HoaDonHocPhis { get; set; }
        public virtual DbSet<Khoi> Khois { get; set; }
        public virtual DbSet<LienKetPHvsH> LienKetPHvsHS { get; set; }
        public virtual DbSet<LoaiDiem> LoaiDiems { get; set; }
        public virtual DbSet<LoaiHanhKiem> LoaiHanhKiems { get; set; }
        public virtual DbSet<LoaiHocSinh> LoaiHocSinhs { get; set; }
        public virtual DbSet<LoaiThongBao> LoaiThongBaos { get; set; }
        public virtual DbSet<LoaiTrangThai> LoaiTrangThais { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<MonCuaKhoi> MonCuaKhois { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<PhanCongDay> PhanCongDays { get; set; }
        public virtual DbSet<TaiKhoanPH> TaiKhoanPHs { get; set; }
        public virtual DbSet<TaiKhoanTruong> TaiKhoanTruongs { get; set; }
        public virtual DbSet<ThongBaoH> ThongBaoHS { get; set; }
        public virtual DbSet<ThongBaoLop> ThongBaoLops { get; set; }
        public virtual DbSet<ThongBaoTruong> ThongBaoTruongs { get; set; }
        public virtual DbSet<ThongTinH> ThongTinHS { get; set; }
        public virtual DbSet<TienHocPhi> TienHocPhis { get; set; }
        public virtual DbSet<XinPhep> XinPheps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Khoi>()
                .HasMany(e => e.Lops)
                .WithOptional(e => e.Khoi)
                .HasForeignKey(e => e.IDKhoi)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Khoi>()
                .HasMany(e => e.MonCuaKhois)
                .WithRequired(e => e.Khoi)
                .HasForeignKey(e => e.IDKhoi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Khoi>()
                .HasMany(e => e.TienHocPhis)
                .WithOptional(e => e.Khoi)
                .HasForeignKey(e => e.IDKhoi)
                .WillCascadeOnDelete();

            modelBuilder.Entity<LoaiDiem>()
                .HasMany(e => e.BangDiems)
                .WithOptional(e => e.LoaiDiem)
                .HasForeignKey(e => e.IDLoaiDiem);

            modelBuilder.Entity<LoaiDiem>()
                .HasMany(e => e.BangDiems1)
                .WithOptional(e => e.LoaiDiem1)
                .HasForeignKey(e => e.IDLoaiDiem);

            modelBuilder.Entity<LoaiHanhKiem>()
                .HasMany(e => e.ThongTinHS)
                .WithOptional(e => e.LoaiHanhKiem)
                .HasForeignKey(e => e.CaNam);

            modelBuilder.Entity<LoaiHanhKiem>()
                .HasMany(e => e.ThongTinHS1)
                .WithOptional(e => e.LoaiHanhKiem1)
                .HasForeignKey(e => e.CaNam);

            modelBuilder.Entity<LoaiHanhKiem>()
                .HasMany(e => e.ThongTinHS2)
                .WithOptional(e => e.LoaiHanhKiem2)
                .HasForeignKey(e => e.HKI);

            modelBuilder.Entity<LoaiHanhKiem>()
                .HasMany(e => e.ThongTinHS3)
                .WithOptional(e => e.LoaiHanhKiem3)
                .HasForeignKey(e => e.HKI);

            modelBuilder.Entity<LoaiHanhKiem>()
                .HasMany(e => e.ThongTinHS4)
                .WithOptional(e => e.LoaiHanhKiem4)
                .HasForeignKey(e => e.HKII)
                .WillCascadeOnDelete();

            modelBuilder.Entity<LoaiHocSinh>()
                .HasMany(e => e.ThongTinHS)
                .WithOptional(e => e.LoaiHocSinh)
                .HasForeignKey(e => e.IDLoaiHocSinh)
                .WillCascadeOnDelete();

            modelBuilder.Entity<LoaiHocSinh>()
                .HasMany(e => e.TienHocPhis)
                .WithOptional(e => e.LoaiHocSinh)
                .HasForeignKey(e => e.IDLoaiHocSinh)
                .WillCascadeOnDelete();

            modelBuilder.Entity<LoaiThongBao>()
                .HasMany(e => e.ThongBaoHS)
                .WithOptional(e => e.LoaiThongBao)
                .HasForeignKey(e => e.IDLoaiThongBao);

            modelBuilder.Entity<LoaiThongBao>()
                .HasMany(e => e.ThongBaoLops)
                .WithOptional(e => e.LoaiThongBao)
                .HasForeignKey(e => e.IDLoaiThongBao)
                .WillCascadeOnDelete();

            modelBuilder.Entity<LoaiThongBao>()
                .HasMany(e => e.ThongBaoTruongs)
                .WithOptional(e => e.LoaiThongBao)
                .HasForeignKey(e => e.IDLoaiThongBao)
                .WillCascadeOnDelete();

            modelBuilder.Entity<LoaiTrangThai>()
                .HasMany(e => e.XinPheps)
                .WithOptional(e => e.LoaiTrangThai)
                .HasForeignKey(e => e.TrangThai);

            modelBuilder.Entity<LoaiTrangThai>()
                .HasMany(e => e.XinPheps1)
                .WithOptional(e => e.LoaiTrangThai1)
                .HasForeignKey(e => e.TrangThai);

            modelBuilder.Entity<Lop>()
                .HasMany(e => e.DTBMons)
                .WithRequired(e => e.Lop)
                .HasForeignKey(e => e.IDLop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lop>()
                .HasMany(e => e.DTBMons1)
                .WithRequired(e => e.Lop1)
                .HasForeignKey(e => e.IDLop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lop>()
                .HasMany(e => e.DTBTongs)
                .WithRequired(e => e.Lop)
                .HasForeignKey(e => e.IDLop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lop>()
                .HasMany(e => e.DTBTongs1)
                .WithRequired(e => e.Lop1)
                .HasForeignKey(e => e.IDLop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lop>()
                .HasMany(e => e.PhanCongDays)
                .WithOptional(e => e.Lop)
                .HasForeignKey(e => e.IDLop)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Lop>()
                .HasMany(e => e.TaiKhoanTruongs)
                .WithOptional(e => e.Lop)
                .HasForeignKey(e => e.IDLop)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Lop>()
                .HasMany(e => e.ThongBaoLops)
                .WithOptional(e => e.Lop)
                .HasForeignKey(e => e.IDLop)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Lop>()
                .HasMany(e => e.ThongTinHS)
                .WithOptional(e => e.Lop)
                .HasForeignKey(e => e.IDLop)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.BangDiems)
                .WithOptional(e => e.MonHoc)
                .HasForeignKey(e => e.IDMonHoc)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.DTBMons)
                .WithRequired(e => e.MonHoc)
                .HasForeignKey(e => e.IDMon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.DTBMons1)
                .WithRequired(e => e.MonHoc1)
                .HasForeignKey(e => e.IDMon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.MonCuaKhois)
                .WithRequired(e => e.MonHoc)
                .HasForeignKey(e => e.IDMon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.TaiKhoanTruongs)
                .WithOptional(e => e.MonHoc)
                .HasForeignKey(e => e.IDMonHoc);

            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.TaiKhoanTruongs1)
                .WithOptional(e => e.MonHoc1)
                .HasForeignKey(e => e.IDMonHoc);

            modelBuilder.Entity<TaiKhoanPH>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoanPH>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoanPH>()
                .Property(e => e.SDTMe)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoanPH>()
                .Property(e => e.SDTBo)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoanPH>()
                .HasMany(e => e.LienKetPHvsHS)
                .WithOptional(e => e.TaiKhoanPH)
                .HasForeignKey(e => e.IDTaiKhoan)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TaiKhoanTruong>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoanTruong>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoanTruong>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoanTruong>()
                .HasMany(e => e.PhanCongDays)
                .WithOptional(e => e.TaiKhoanTruong)
                .HasForeignKey(e => e.IDGiaoVien);

            modelBuilder.Entity<TaiKhoanTruong>()
                .HasMany(e => e.PhanCongDays1)
                .WithOptional(e => e.TaiKhoanTruong1)
                .HasForeignKey(e => e.IDGiaoVien);

            modelBuilder.Entity<ThongTinH>()
                .HasMany(e => e.BangDiems)
                .WithOptional(e => e.ThongTinH)
                .HasForeignKey(e => e.IDHocSinh)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ThongTinH>()
                .HasOptional(e => e.BHYT)
                .WithRequired(e => e.ThongTinH)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ThongTinH>()
                .HasMany(e => e.CupHocs)
                .WithOptional(e => e.ThongTinH)
                .HasForeignKey(e => e.IDHocSinh)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ThongTinH>()
                .HasMany(e => e.DiemDanhs)
                .WithOptional(e => e.ThongTinH)
                .HasForeignKey(e => e.IDHocSinh)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ThongTinH>()
                .HasMany(e => e.DTBMons)
                .WithRequired(e => e.ThongTinH)
                .HasForeignKey(e => e.IDHocSinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThongTinH>()
                .HasMany(e => e.DTBMons1)
                .WithRequired(e => e.ThongTinH1)
                .HasForeignKey(e => e.IDHocSinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThongTinH>()
                .HasMany(e => e.DTBTongs)
                .WithRequired(e => e.ThongTinH)
                .HasForeignKey(e => e.IDHocSinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThongTinH>()
                .HasMany(e => e.DTBTongs1)
                .WithRequired(e => e.ThongTinH1)
                .HasForeignKey(e => e.IDHocSinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThongTinH>()
                .HasOptional(e => e.LienKetPHvsH)
                .WithRequired(e => e.ThongTinH)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ThongTinH>()
                .HasMany(e => e.ThongBaoHS)
                .WithOptional(e => e.ThongTinH)
                .HasForeignKey(e => e.IDHocSinh)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ThongTinH>()
                .HasMany(e => e.XinPheps)
                .WithOptional(e => e.ThongTinH)
                .HasForeignKey(e => e.IDHocSinh)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TienHocPhi>()
                .HasMany(e => e.HoaDonHocPhis)
                .WithOptional(e => e.TienHocPhi)
                .HasForeignKey(e => e.IDHocPhi);
        }
    }
}
