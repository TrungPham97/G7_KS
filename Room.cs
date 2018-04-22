namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Room")]
    public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            CTIET_Payment = new HashSet<CTIET_Payment>();
            Rentings = new HashSet<Renting>();
        }

        [Key]
        [StringLength(7)]
        public string MaPhong { get; set; }

        [StringLength(50)]
        public string TinhTrang { get; set; }

        [StringLength(5)]
        public string MaLoaiPhong { get; set; }

        [StringLength(10)]
        public string TenPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTIET_Payment> CTIET_Payment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Renting> Rentings { get; set; }
    }
}
