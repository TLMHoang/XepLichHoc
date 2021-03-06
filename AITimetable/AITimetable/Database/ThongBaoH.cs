namespace AITimetable.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.ThongBaoHS")]
    public partial class ThongBaoH
    {
        public int ID { get; set; }

        public int? IDHocSinh { get; set; }

        public string NoiDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        public int? IDLoaiThongBao { get; set; }

        public virtual LoaiThongBao LoaiThongBao { get; set; }

        public virtual ThongTinH ThongTinH { get; set; }
    }
}
