namespace ProjectDomain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Enroll
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

        public int? Passed { get; set; }

        public double? Hw1Grade { get; set; }

        public double? Hw2Grade { get; set; }

        public double? Hw3Grade { get; set; }

        public double? Hw4Grade { get; set; }

        public double? Hw5Grade { get; set; }

        [StringLength(5)]
        public string ExamGrade { get; set; }

        public virtual Class Class { get; set; }

        public virtual Student Student { get; set; }
    }
}
