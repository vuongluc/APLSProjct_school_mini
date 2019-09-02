using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain.DTOs
{
    public class ClassDTO
    {
        public string ClassId { get; set; }

        public int? TeachingHour { get; set; }

        public string ModuleId { get; set; }

        public string StatusId { get; set; }

        public string TeacherId { get; set; }

        public string TypeId { get; set; }
    }
}
