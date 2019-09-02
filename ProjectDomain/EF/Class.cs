namespace ProjectDomain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Class
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Class()
        {
            Enrolls = new HashSet<Enroll>();
            Evaluates = new HashSet<Evaluate>();
        }

        [StringLength(15)]
        public string ClassId { get; set; }

        public int? TeachingHour { get; set; }

        [StringLength(5)]
        public string ModuleId { get; set; }

        [StringLength(3)]
        public string StatusId { get; set; }

        [StringLength(11)]
        public string TeacherId { get; set; }

        [StringLength(1)]
        public string TypeId { get; set; }

        public virtual Module Module { get; set; }

        public virtual Status Status { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual ClassType ClassType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Enroll> Enrolls { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evaluate> Evaluates { get; set; }
    }
}
