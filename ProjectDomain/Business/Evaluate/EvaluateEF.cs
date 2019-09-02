using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain.DTOs;
using ProjectDomain.EF;

namespace ProjectDomain.Business.Evaluate
{
    public class EvaluateEF : IEvaluatesBusiness
    {
        public void createEvaluate(EvaluateDTO newEvalua)
        {
            using (var db = new ProjectDbContext())
            {
                var evalua = DTOEFMapper.GetEntityFromDTO(newEvalua);
                db.Evaluates.Add(evalua);
                db.SaveChanges();
            }
        }

        public List<EvaluateDTO> findAllEvaluate()
        {
            using (var db = new ProjectDbContext())
            {
                List<EvaluateDTO> teachers = new List<EvaluateDTO>();
                foreach (var entity in db.Evaluates)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(entity);
                    teachers.Add(dto);
                }
                return teachers;
            }
        }

        public EvaluateDTO findById(string evaluaId)
        {
            using (var db = new ProjectDbContext())
            {
                var entity = db.Evaluates.Where(x => x.StudentId +x.ClassId == evaluaId).FirstOrDefault();
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

        public List<EvaluateDTO> search(string query)
        {
            List<EvaluateDTO> dtos = new List<EvaluateDTO>();
            using (var db = new ProjectDbContext())
            {
                var entities = db.Evaluates
                                .Where(e => (e.Student.FirstName.Contains(query) || e.Student.LastName.Contains(query)) ||
                                                string.IsNullOrEmpty(query));
                foreach (var entity in entities)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(entity);
                    dtos.Add(dto);
                }
                return dtos;
            }
        }

        public void updateEvaluate(EvaluateDTO updateEvalua)
        {
            using (var db = new ProjectDbContext())
            {
                var evalua = db.Evaluates.Where(m => m.StudentId + m.ClassId == updateEvalua.StudentId+ updateEvalua.ClassId).FirstOrDefault();
                if (evalua != null)
                {
                    db.Entry(evalua).CurrentValues.SetValues(updateEvalua);
                    db.SaveChanges();
                }
            }
        }
    }
}
