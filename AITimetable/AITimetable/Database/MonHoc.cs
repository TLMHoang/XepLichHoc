namespace AITimetable.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.MonHoc")]
    public partial class MonHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MonHoc()
        {
            TaiKhoanTruongs = new HashSet<TaiKhoanTruong>();
            TaiKhoanTruongs1 = new HashSet<TaiKhoanTruong>();
            Khois = new HashSet<Khoi>();
        }

        public int ID { get; set; }

        [StringLength(200)]
        public string TenMon { get; set; }

        public bool? LoaiDiem { get; set; }

        public bool? CoDiem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiKhoanTruong> TaiKhoanTruongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiKhoanTruong> TaiKhoanTruongs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Khoi> Khois { get; set; }
    }
}
