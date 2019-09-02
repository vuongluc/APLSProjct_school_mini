using ProjectDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain.Business
{
    public interface IModuleBusiness
    {
        List<ModuleDTO> findAllModule();
        ModuleDTO findById(string moduleID);
        void createModule(ModuleDTO newModule);
        void updateModule(ModuleDTO updateModule);
        void deleteModule(string moduleID);
        List<ModuleDTO> search(string query);
        void importData(string path);
        List<string> listId();
    }
}
