﻿namespace AITimetable.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nxtckedu_sa.Khoi")]
    public partial class Khoi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Khoi()
        {
            Lops = new HashSet<Lop>();
            MonCuaKhois = new HashSet<MonCuaKhoi>();
            TienHocPhis = new HashSet<TienHocPhi>();
        }

        public int ID { get; set; }

        [StringLength(20)]
        public string TenKhoi { get; set; }

        public bool? BuoiSang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lop> Lops { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonCuaKhoi> MonCuaKhois { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TienHocPhi> TienHocPhis { get; set; }

        public override string ToString()
        {
            return "Khối " + TenKhoi;
        }
    }
}
