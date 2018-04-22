namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Renting")]
    public partial class Renting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Renting()
        {
            CTIET_Renting = new HashSet<CTIET_Renting>();
        }

        [Key]
        [StringLength(10)]
        public string MaPhieuThue { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBatDauThue { get; set; }

        [StringLength(7)]
        public string MaPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTIET_Renting> CTIET_Renting { get; set; }

        public virtual Room Room { get; set; }
    }
}
