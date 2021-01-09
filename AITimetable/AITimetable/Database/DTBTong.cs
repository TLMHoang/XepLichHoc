namespace AITimetable.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.DTBTong")]
    public partial class DTBTong
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDHocSinh { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDLop { get; set; }

        public double? HKI { get; set; }

        public double? HKII { get; set; }

        public double? CaNam { get; set; }

        public virtual ThongTinH ThongTinH { get; set; }

        public virtual ThongTinH ThongTinH1 { get; set; }

        public virtual Lop Lop { get; set; }

        public virtual Lop Lop1 { get; set; }
    }
}
