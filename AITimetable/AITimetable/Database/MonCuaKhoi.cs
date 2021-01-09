namespace AITimetable.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.MonCuaKhoi")]
    public partial class MonCuaKhoi
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDKhoi { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDMon { get; set; }

        public int? TietTrongTuan { get; set; }

        public int? TIetTrongNgay { get; set; }

        public virtual Khoi Khoi { get; set; }

        public virtual MonHoc MonHoc { get; set; }
    }
}
