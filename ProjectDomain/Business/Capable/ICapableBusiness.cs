using ProjectDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain.Business.Capable
{
    public interface ICapableBusiness
    {
        List<CapableDTO> findAllCapable();
        List<CapableDTO> findById(string teacherID);
        void createCapable(CapableDTO newCapable);
        void updateCapable(CapableDTO updateCapable);
        void deleteCapable(string teacherID);
    }
}
