namespace AITimetable.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.HoaDonHocPhi")]
    public partial class HoaDonHocPhi
    {
        public int ID { get; set; }

        public int? IDHocPhi { get; set; }

        public DateTime? NgayTao { get; set; }

        public int? IDHocSinh { get; set; }

        public bool? ThanhToan { get; set; }

        public virtual TienHocPhi TienHocPhi { get; set; }
    }
}
