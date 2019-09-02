using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain.DTOs;
using ProjectDomain.EF;
using System.IO;

namespace ProjectDomain.Business.Class
{
    public class ClassEF : IClassBusiness
    {
        public void createClass(ClassDTO newClass)
        {
            using (var db = new ProjectDbContext())
            {
                var classes = DTOEFMapper.GetEntityFromDTO(newClass);
                db.Classes.Add(classes);
                db.SaveChanges();
            }
        }

        public List<ClassDTO> findAllClass()
        {
            using (var db = new ProjectDbContext())
            {
                List<ClassDTO> classes = new List<ClassDTO>();
                foreach (var entity in db.Classes)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(entity);
                    classes.Add(dto);
                }
                return classes;
            }
        }

        public ClassDTO findById(string classID)
        {
            using (var db = new ProjectDbContext())
            {
                var entity = db.Classes.Where(x => x.ClassId == classID).FirstOrDefault();
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
                    var newClass = new ClassDTO
                    {
                        ClassId = data[0],
                        TeachingHour = Convert.ToInt32(data[1]),
                        ModuleId = data[2],
                        StatusId = data[3],
                        TeacherId = data[4],
                        TypeId = data[5]

                    };
                    var dto = DTOEFMapper.GetEntityFromDTO(newClass);
                    db.Classes.Add(dto);
                    db.SaveChanges();
                }
            }
        }

        public List<string> listId()
        {
            List<string> listID = new List<string>();
            using (var db = new ProjectDbContext())
            {
                foreach (var item in db.Classes)
                {
                    listID.Add(item.ClassId.ToString());
                }
                return listID;
            }
        }

        public List<ClassDTO> search(string query)
        {
            List<ClassDTO> dtos = new List<ClassDTO>();
            using (var db = new ProjectDbContext())
            {

                var entities = db.Classes
                                .Where(e =>(e.Teacher.FirstName.Contains(query) || e.Teacher.LastName.Contains(query)) ||
                                                string.IsNullOrEmpty(query));
                foreach (var entity in entities)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(entity);
                    dtos.Add(dto);
                }
                return dtos;
            }
        }

        public void updateClass(ClassDTO updateClass)
        {
            using (var db = new ProjectDbContext())
            {
                var teacher = db.Classes.Where(m => m.ClassId == updateClass.ClassId).FirstOrDefault();
                if (teacher != null)
                {
                    db.Entry(teacher).CurrentValues.SetValues(updateClass);
                    db.SaveChanges();
                }
            }
        }
    }
}
