namespace AITimetable.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.LoaiThongBao")]
    public partial class LoaiThongBao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiThongBao()
        {
            ThongBaoHS = new HashSet<ThongBaoH>();
            ThongBaoLops = new HashSet<ThongBaoLop>();
            ThongBaoTruongs = new HashSet<ThongBaoTruong>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string TenThongBao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongBaoH> ThongBaoHS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongBaoLop> ThongBaoLops { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongBaoTruong> ThongBaoTruongs { get; set; }
    }
}
