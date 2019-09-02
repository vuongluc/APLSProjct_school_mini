using ProjectDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain.Business.Enroll
{
    public interface IEnrollBusiness
    {
        List<EnrollDTO> findAllEnroll();
        EnrollDTO findById(string enrollID);
        void createEnroll(EnrollDTO newEnroll);
        void updateEnroll(EnrollDTO updateEnroll);
        void deleteEnroll(string studentID);
        List<EnrollDTO> search(string query);
        void importData(string path);
        List<string> listId();
    }
}
