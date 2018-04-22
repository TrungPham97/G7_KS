namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADMIN")]
    public partial class ADMIN
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }

        
        [StringLength(50)]
        [Display(Name = "Mật khẩu")] 
        public string Password { get; set; }
    }
}
