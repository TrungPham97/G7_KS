namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class THAM_SO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTS { get; set; }

        public int? SoKhachToiDa { get; set; }

        public decimal? PhuThu { get; set; }

        [StringLength(50)]
        public string SoLuongLoaiPhong { get; set; }

        public decimal? DonGia { get; set; }

        public int? SoLuongLoaiKhach { get; set; }
    }
}
