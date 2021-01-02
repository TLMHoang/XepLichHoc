namespace AITimetable.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.TaiKhoanTruong")]
    public partial class TaiKhoanTruong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
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
    }
}
