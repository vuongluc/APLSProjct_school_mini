using ProjectDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain.Business.Class
{
    public interface IClassBusiness
    {
        List<ClassDTO> findAllClass();
        ClassDTO findById(string classID);
        void createClass(ClassDTO newClass);
        void updateClass(ClassDTO updateClass);
        List<ClassDTO> search(string query);
        void importData(string path);
        List<string> listId();
    }
}
