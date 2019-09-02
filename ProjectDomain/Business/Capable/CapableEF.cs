using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain.DTOs;
using ProjectDomain.EF;

namespace ProjectDomain.Business.Capable
{
    public class CapableEF : ICapableBusiness
    {
        public void createCapable(CapableDTO newCapable)
        {
            using (var db = new ProjectDbContext())
            {
                var cappable = DTOEFMapper.GetEntityFromDTO(newCapable);
                db.Capables.Add(cappable);
                db.SaveChanges();
            }
        }

        public void deleteCapable(string teacherID)
        {
            using (var db = new ProjectDbContext())
            {
                var capable = db.Capables.Where(x => x.TeacherId == teacherID).FirstOrDefault();
                if (capable != null)
                {
                    foreach (var capabless in db.Capables.Where(x => x.TeacherId == teacherID).ToList())
                    {
                        db.Capables.Remove(capabless);
                        db.SaveChanges();
                    }                    
                }
            }
        }

        public List<CapableDTO> findAllCapable()
        {
            List<CapableDTO> capables = new List<CapableDTO>();
            using (var db = new ProjectDbContext())
            {
                foreach (var capable in db.Capables)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(capable);
                    capables.Add(dto);
                }
                return capables;
            }
        }

        public List<CapableDTO> findById(string teacherID)
        {
            List<CapableDTO> capables = new List<CapableDTO>();
            using (var db = new ProjectDbContext())
            {
                var capable = db.Capables.Where(x => x.TeacherId == teacherID).FirstOrDefault();
                if (capable != null)
                {
                    foreach (var capabless in db.Capables.Where(x => x.TeacherId == teacherID))
                    {
                        var dto = DTOEFMapper.GetDtoFromEntity(capabless);
                        capables.Add(dto);
                    }
                    return capables;
                }
                else
                {
                    return null;
                }
            }
        }

        public void updateCapable(CapableDTO updateCapable)
        {
            using (var db = new ProjectDbContext())
            {
                var student = db.Capables.Where(x => x.id == updateCapable.id).FirstOrDefault();
                if (student != null)
                {
                    db.Entry(student).CurrentValues.SetValues(updateCapable);
                    db.SaveChanges();
                }
            }
        }
    }
}
