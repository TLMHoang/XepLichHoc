namespace AITimetable.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.BHYT")]
    public partial class BHYT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDHocSinh { get; set; }

        public bool? DangKy { get; set; }

        public bool? BHQD { get; set; }

        public virtual ThongTinH ThongTinH { get; set; }
    }
}
