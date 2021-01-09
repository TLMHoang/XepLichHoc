namespace AITimetable.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.MonHoc")]
    public partial class MonHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MonHoc()
        {
            BangDiems = new HashSet<BangDiem>();
            DTBMons = new HashSet<DTBMon>();
            DTBMons1 = new HashSet<DTBMon>();
            MonCuaKhois = new HashSet<MonCuaKhoi>();
            TaiKhoanTruongs = new HashSet<TaiKhoanTruong>();
            TaiKhoanTruongs1 = new HashSet<TaiKhoanTruong>();
        }

        public int ID { get; set; }

        [StringLength(200)]
        public string TenMon { get; set; }

        public bool? LoaiDiem { get; set; }

        public bool? CoDiem { get; set; }

        public bool? ChinhKhoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangDiem> BangDiems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DTBMon> DTBMons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DTBMon> DTBMons1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonCuaKhoi> MonCuaKhois { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiKhoanTruong> TaiKhoanTruongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiKhoanTruong> TaiKhoanTruongs1 { get; set; }

        public override string ToString()
        {
            return TenMon;
        }


        public string[] ToItem(List<MonHoc> lst)
        {
            string[] aStr = new string[lst.Count];

            for (int i = 0; i < lst.Count; i++)
            {
                aStr[i] = lst[i].ToString();
            }

            return aStr;
        }
    }
}
