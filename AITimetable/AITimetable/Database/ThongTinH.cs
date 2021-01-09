namespace AITimetable.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.ThongTinHS")]
    public partial class ThongTinH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThongTinH()
        {
            BangDiems = new HashSet<BangDiem>();
            CupHocs = new HashSet<CupHoc>();
            DiemDanhs = new HashSet<DiemDanh>();
            DTBMons = new HashSet<DTBMon>();
            DTBMons1 = new HashSet<DTBMon>();
            DTBTongs = new HashSet<DTBTong>();
            DTBTongs1 = new HashSet<DTBTong>();
            ThongBaoHS = new HashSet<ThongBaoH>();
            XinPheps = new HashSet<XinPhep>();
        }

        public int ID { get; set; }

        [StringLength(200)]
        public string Ten { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        public bool? GioiTinh { get; set; }

        [StringLength(250)]
        public string NoiSinh { get; set; }

        [StringLength(100)]
        public string DanToc { get; set; }

        [StringLength(100)]
        public string TonGiao { get; set; }

        public int? IDLop { get; set; }

        public int? IDLoaiHocSinh { get; set; }

        public int? HKI { get; set; }

        public int? HKII { get; set; }

        public int? CaNam { get; set; }

        public int? Tien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangDiem> BangDiems { get; set; }

        public virtual BHYT BHYT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CupHoc> CupHocs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiemDanh> DiemDanhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DTBMon> DTBMons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DTBMon> DTBMons1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DTBTong> DTBTongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DTBTong> DTBTongs1 { get; set; }

        public virtual LienKetPHvsH LienKetPHvsH { get; set; }

        public virtual LoaiHanhKiem LoaiHanhKiem { get; set; }

        public virtual LoaiHanhKiem LoaiHanhKiem1 { get; set; }

        public virtual LoaiHanhKiem LoaiHanhKiem2 { get; set; }

        public virtual LoaiHanhKiem LoaiHanhKiem3 { get; set; }

        public virtual LoaiHanhKiem LoaiHanhKiem4 { get; set; }

        public virtual LoaiHocSinh LoaiHocSinh { get; set; }

        public virtual Lop Lop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongBaoH> ThongBaoHS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XinPhep> XinPheps { get; set; }
    }
}
