namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Payment()
        {
            CTIET_Payment = new HashSet<CTIET_Payment>();
        }

        [Key]
        [StringLength(10)]
        public string MaHoaDon { get; set; }

        [StringLength(50)]
        public string TenKH { get; set; }

        public decimal? TriGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTIET_Payment> CTIET_Payment { get; set; }
    }
}
