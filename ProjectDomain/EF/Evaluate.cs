namespace ProjectDomain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Evaluate
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(11)]
        public string StudentId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string ClassId { get; set; }

        [StringLength(30)]
        public string id { get; set; }

        [StringLength(255)]
        public string Understand { get; set; }

        [StringLength(255)]
        public string Punctuality { get; set; }

        [StringLength(255)]
        public string Support { get; set; }

        [StringLength(255)]
        public string Teaching { get; set; }

        public virtual Class Class { get; set; }

        public virtual Student Student { get; set; }
    }
}
