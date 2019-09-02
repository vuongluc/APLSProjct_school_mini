using ProjectDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain.Business
{
    public interface IStatusBusiness
    {
        List<StatusDTO> fidAllStatus();
        StatusDTO findById(string statusID);
        void createStatus(StatusDTO newStatus);
        void updateStatus(StatusDTO updateStatus);
        void deleteStatus(string statusID);
        List<StatusDTO> search(string query);
        void importData(string path);
        List<string> listId();
    }
}
