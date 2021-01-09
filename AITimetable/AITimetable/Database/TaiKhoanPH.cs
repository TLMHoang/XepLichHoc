namespace AITimetable.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.TaiKhoanPH")]
    public partial class TaiKhoanPH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoanPH()
        {
            LienKetPHvsHS = new HashSet<LienKetPHvsH>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string TaiKhoan { get; set; }

        [StringLength(500)]
        public string MatKhau { get; set; }

        [StringLength(150)]
        public string TenMe { get; set; }

        [StringLength(12)]
        public string SDTMe { get; set; }

        [StringLength(150)]
        public string TenBo { get; set; }

        [StringLength(12)]
        public string SDTBo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LienKetPHvsH> LienKetPHvsHS { get; set; }
    }
}
