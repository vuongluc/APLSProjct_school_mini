using ProjectDomain.DTOs;
using ProjectDomain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain.Business
{
    public interface IClassTypeBusiness
    {
        List<ClassTypesDTO> findAllClassType();
        ClassTypesDTO findById(string classID);
        void createClass(ClassTypesDTO newClass);
        void updateClass(ClassTypesDTO updateClass);
        void deleteClass(string classID);
        List<ClassTypesDTO> search(string query);
        void importData(string path);
        List<string> listId();
    }
}
