using ProjectDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain.Business
{
    public interface IStudentBusiness
    {
        List<StudentDTO> findAllStudent();
        StudentDTO findById(string studentID);
        void createStudent(StudentDTO newStudent);
        void updateStudent(StudentDTO updateStudent);
        void deleteStudent(string studentID);
        List<StudentDTO> search(string query);
        void importData(string path);
        List<string> listId();
    }
}
