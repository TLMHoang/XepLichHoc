namespace AITimetable.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.DiemDanh")]
    public partial class DiemDanh
    {
        public int ID { get; set; }

        public int? IDHocSinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNghi { get; set; }

        public bool? Phep { get; set; }

        public virtual ThongTinH ThongTinH { get; set; }
    }
}
