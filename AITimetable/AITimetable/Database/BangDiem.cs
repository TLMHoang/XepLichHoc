namespace AITimetable.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.BangDiem")]
    public partial class BangDiem
    {
        public int ID { get; set; }

        public int? IDHocSinh { get; set; }

        public int? IDMonHoc { get; set; }

        public int? IDLoaiDiem { get; set; }

        public double? Diem { get; set; }

        public bool? HocKyI { get; set; }

        public int? CotDiem { get; set; }

        public virtual LoaiDiem LoaiDiem { get; set; }

        public virtual LoaiDiem LoaiDiem1 { get; set; }

        public virtual MonHoc MonHoc { get; set; }

        public virtual ThongTinH ThongTinH { get; set; }
    }
}
