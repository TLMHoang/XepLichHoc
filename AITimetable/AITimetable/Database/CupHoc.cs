namespace AITimetable.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.CupHoc")]
    public partial class CupHoc
    {
        public int ID { get; set; }

        public int? IDHocSinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        public int? Tiet { get; set; }

        public virtual ThongTinH ThongTinH { get; set; }
    }
}
