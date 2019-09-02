using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain.DTOs;
using ProjectDomain.EF;
using System.IO;

namespace ProjectDomain.Business
{
    public class StatusEF : IStatusBusiness
    {
        public void createStatus(StatusDTO newStatus)
        {
            using (var db = new ProjectDbContext())
            {
                var status = DTOEFMapper.GetEntityFromDTO(newStatus);
                db.Status.Add(status);
                db.SaveChanges();
            }
        }

        public void deleteStatus(string statusID)
        {
            using (var db = new ProjectDbContext())
            {
                var status = db.Status.Where(m => m.StatusId == statusID).FirstOrDefault();
                if (status != null)
                {
                    db.Status.Remove(status);
                    db.SaveChanges();
                }
            }
        }

        public List<StatusDTO> fidAllStatus()
        {

            using (var db = new ProjectDbContext())
            {
                List<StatusDTO> status = new List<StatusDTO>();
                foreach (var entity in db.Status)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(entity);
                    status.Add(dto);
                }
                return status;
            }
        }

        public StatusDTO findById(string statusID)
        {
            using (var db = new ProjectDbContext())
            {
                var entity = db.Status.Where(x => x.StatusId == statusID).FirstOrDefault();
                if (entity != null)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(entity);
                    return dto;
                }
                else
                {
                    return null;
                }
            }
        }

        public void importData(string path)
        {
            using (var db = new ProjectDbContext())
            {
                StreamReader streamCsv = new StreamReader(path);

                string csvDataLine = "";
                string[] data = null;
                var lineHeader = streamCsv.ReadLine();
                while ((csvDataLine = streamCsv.ReadLine()) != null)
                {
                    data = csvDataLine.Split(',');
                    var newStatus = new Status
                    {
                        StatusId = data[0],
                        Description = data[1],
                        StatusName = data[2]
                    };
                    db.Status.Add(newStatus);
                    db.SaveChanges();
                }
            }
        }

        public List<string> listId()
        {
            List<string> listID = new List<string>();
            using (var db = new ProjectDbContext())
            {
                foreach (var item in db.Status)
                {
                    listID.Add(item.StatusId.ToString());
                }
                return listID;
            }
        }


        public List<StatusDTO> search(string query)
        {
            List<StatusDTO> dtos = new List<StatusDTO>();
            using (var db = new ProjectDbContext())
            {
                var entities = db.Status
                                .Where(e => e.StatusName.Contains(query) ||
                                                string.IsNullOrEmpty(query));
                foreach (var entity in entities)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(entity);
                    dtos.Add(dto);
                }
                return dtos;
            }
        }

        public void updateStatus(StatusDTO updateStatus)
        {
            using (var db = new ProjectDbContext())
            {
                var status = db.Status.Where(m => m.StatusId == updateStatus.StatusId).FirstOrDefault();
                if (status != null)
                {
                    db.Entry(status).CurrentValues.SetValues(updateStatus);
                    db.SaveChanges();
                }
            }
        }
    }
}
