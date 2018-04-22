namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BAO_CAO_DOANH_THU
    {
        [Key]
        [StringLength(10)]
        public string MaBaoCao { get; set; }

        public int? Thang { get; set; }

        [StringLength(5)]
        public string TenLoaiPhong { get; set; }

        public decimal? DoanhThu { get; set; }

        public decimal? TyLe { get; set; }
    }
}
