namespace AITimetable.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.Lop")]
    public partial class Lop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lop()
        {
            PhanCongDays = new HashSet<PhanCongDay>();
            TaiKhoanTruongs = new HashSet<TaiKhoanTruong>();
        }

        public int ID { get; set; }

        public int? IDKhoi { get; set; }

        [StringLength(50)]
        public string TenLop { get; set; }

        public virtual Khoi Khoi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanCongDay> PhanCongDays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiKhoanTruong> TaiKhoanTruongs { get; set; }
    }
}
