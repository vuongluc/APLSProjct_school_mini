using ProjectDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain.Business
{
    public interface ITeacherBusiness
    {
        List<TeacherDTO> findAllTeacher();
        TeacherDTO findById(string teacherID);
        void createTeacher(TeacherDTO newTeacher);
        void updateTeacher(TeacherDTO updateTeacher);
        void deleteTeacher(string teacherID);
        List<TeacherDTO> search(string query);
        void importData(string path);
        List<string> listId();
    }
}
