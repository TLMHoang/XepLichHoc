namespace DTO
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

        public virtual DbSet<Khoi> Khois { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<PhanCongDay> PhanCongDays { get; set; }
        public virtual DbSet<TaiKhoanTruong> TaiKhoanTruongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Khoi>()
                .HasMany(e => e.Lops)
                .WithOptional(e => e.Khoi)
                .HasForeignKey(e => e.IDKhoi)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Khoi>()
                .HasMany(e => e.MonHocs)
                .WithMany(e => e.Khois)
                .Map(m => m.ToTable("MonCuaKhoi", "nxtckedu_sa").MapLeftKey("IDKhoi").MapRightKey("IDMon"));

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

            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.TaiKhoanTruongs)
                .WithOptional(e => e.MonHoc)
                .HasForeignKey(e => e.IDMonHoc);

            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.TaiKhoanTruongs1)
                .WithOptional(e => e.MonHoc1)
                .HasForeignKey(e => e.IDMonHoc);

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
        }
    }
}
