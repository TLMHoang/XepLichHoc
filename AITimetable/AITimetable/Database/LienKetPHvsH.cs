namespace AITimetable.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.LienKetPHvsHS")]
    public partial class LienKetPHvsH
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDHocSinh { get; set; }

        public int? IDTaiKhoan { get; set; }

        public virtual TaiKhoanPH TaiKhoanPH { get; set; }

        public virtual ThongTinH ThongTinH { get; set; }
    }
}
