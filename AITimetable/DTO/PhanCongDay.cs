namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.PhanCongDay")]
    public partial class PhanCongDay
    {
        public int ID { get; set; }

        public int? IDGiaoVien { get; set; }

        public int? IDLop { get; set; }

        public virtual Lop Lop { get; set; }

        public virtual TaiKhoanTruong TaiKhoanTruong { get; set; }

        public virtual TaiKhoanTruong TaiKhoanTruong1 { get; set; }
    }
}
