namespace ProjectDomain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account
    {
        [Key]
        [StringLength(15)]
        public string username { get; set; }

        [StringLength(50)]
        public string salf { get; set; }

        [StringLength(100)]
        public string password { get; set; }
    }
}
