namespace AITimetable.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.TienHocPhi")]
    public partial class TienHocPhi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TienHocPhi()
        {
            HoaDonHocPhis = new HashSet<HoaDonHocPhi>();
        }

        public int ID { get; set; }

        public int? Thang { get; set; }

        public int? IDLoaiHocSinh { get; set; }

        public int? IDKhoi { get; set; }

        public int? SoNgayHoc { get; set; }

        public int? TienHoc { get; set; }

        public int? TienAn { get; set; }

        public int? TienDien { get; set; }

        public int? TienNuoc { get; set; }

        public int? TienVeSinh { get; set; }

        public int? TienTrangThietBi { get; set; }

        public int? TienTaiLieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonHocPhi> HoaDonHocPhis { get; set; }

        public virtual Khoi Khoi { get; set; }

        public virtual LoaiHocSinh LoaiHocSinh { get; set; }
    }
}
