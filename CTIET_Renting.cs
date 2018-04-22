namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CTIET_Renting
    {
        [Key]
        [StringLength(10)]
        public string MaChiTietPT { get; set; }

        [StringLength(10)]
        public string MaPhieuThue { get; set; }

        [StringLength(10)]
        public string MaKH { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Renting Renting { get; set; }
    }
}
