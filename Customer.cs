namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            CTIET_Renting = new HashSet<CTIET_Renting>();
        }

        [Key]
        [StringLength(10)]
        public string MaKH { get; set; }

        [StringLength(50)]
        public string TenKH { get; set; }

        [StringLength(12)]
        public string CMND { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        public int? MaLoaiKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTIET_Renting> CTIET_Renting { get; set; }

        public virtual Type_Cus Type_Cus { get; set; }
    }
}
