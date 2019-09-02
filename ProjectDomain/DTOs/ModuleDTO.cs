using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain.DTOs
{
    public class ModuleDTO
    {
        public string ModuleId { get; set; }

        public byte Duration { get; set; }

        public string ModuleName { get; set; }

        public byte Homework { get; set; }
    }
}
