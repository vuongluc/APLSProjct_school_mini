namespace ProjectDomain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Capable
    {
        public int id { get; set; }

        [StringLength(5)]
        public string ModuleId { get; set; }

        [StringLength(11)]
        public string TeacherId { get; set; }

        public virtual Module Module { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
