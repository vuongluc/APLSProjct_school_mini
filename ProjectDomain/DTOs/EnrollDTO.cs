using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain.DTOs
{
    public class EnrollDTO
    {
        
        public string StudentId { get; set; }
        
        public string ClassId { get; set; }

        //public string id { get; set; }

        public int? Passed { get; set; }

        public double? Hw1Grade { get; set; }

        public double? Hw2Grade { get; set; }

        public double? Hw3Grade { get; set; }

        public double? Hw4Grade { get; set; }

        public double? Hw5Grade { get; set; }

        public string ExamGrade { get; set; }
    }
}
