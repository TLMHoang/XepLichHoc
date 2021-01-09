namespace AITimetable.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.XinPhep")]
    public partial class XinPhep
    {
        public int ID { get; set; }

        public int? IDHocSinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NghiTu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NghiDen { get; set; }

        public int? TrangThai { get; set; }

        [StringLength(1000)]
        public string LyDo { get; set; }

        public virtual LoaiTrangThai LoaiTrangThai { get; set; }

        public virtual LoaiTrangThai LoaiTrangThai1 { get; set; }

        public virtual ThongTinH ThongTinH { get; set; }
    }
}
