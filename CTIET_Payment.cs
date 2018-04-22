namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CTIET_Payment
    {
        [Key]
        [StringLength(10)]
        public string MaChiTietHD { get; set; }

        [StringLength(10)]
        public string MaHoaDon { get; set; }

        public int? SoNgayThue { get; set; }

        public decimal? DonGia { get; set; }

        public decimal? ThanhTien { get; set; }

        [StringLength(10)]
        public string NgayThanhToan { get; set; }

        [StringLength(7)]
        public string MaPhong { get; set; }

        public virtual Payment Payment { get; set; }

        public virtual Room Room { get; set; }
    }
}
