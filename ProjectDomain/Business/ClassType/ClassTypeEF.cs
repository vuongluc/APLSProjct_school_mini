using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain.DTOs;
using ProjectDomain.EF;
using System.Data.Entity;
using System.IO;

namespace ProjectDomain.Business
{
    
    public class ClassTypeEF : IClassTypeBusiness
    {
        
        public void createClass(ClassTypesDTO newClass)
        {
            using (var db = new ProjectDbContext())
            {
                var classType = DTOEFMapper.GetEntityFromDTO(newClass);
                db.ClassTypes.Add(classType);
                db.SaveChanges();
            }
        }

        public void deleteClass(string classID)
        {
            using (var db = new ProjectDbContext())
            {
                var classType = db.ClassTypes.Where(m => m.TypeId == classID).FirstOrDefault();
                if(classType != null)
                {
                    db.ClassTypes.Remove(classType);
                    db.SaveChanges();
                }
            }
        }

        public List<ClassTypesDTO> findAllClassType()
        {
            using (var db = new ProjectDbContext())
            {
                List<ClassTypesDTO> classType = new List<ClassTypesDTO>();
                foreach (var entity in db.ClassTypes)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(entity);
                    classType.Add(dto);
                }
                return classType;
            }
        }

        public ClassTypesDTO findById(string classID)
        {
            using(var db = new ProjectDbContext())
            {
                var entity = db.ClassTypes.Where(x => x.TypeId == classID).FirstOrDefault();
                if(entity != null)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(entity);
                    return dto;
                }else
                {
                    return null;
                }
            }
        }
       
        public void updateClass(ClassTypesDTO updateClass)
        {
            using (var db = new ProjectDbContext())
            {
                var classType = db.ClassTypes.Where(m => m.TypeId == updateClass.TypeId).FirstOrDefault();
                if (classType != null)
                {
                    db.Entry(classType).CurrentValues.SetValues(updateClass);
                    db.SaveChanges();
                }
            }
        }

        public List<ClassTypesDTO> search(string query)
        {
            List<ClassTypesDTO> dtos = new List<ClassTypesDTO>();
            using (var db = new ProjectDbContext())
            {
                var entities = db.ClassTypes
                                .Where(e => e.TypeId.Contains(query) ||
                                                string.IsNullOrEmpty(query));
                foreach (var entity in entities)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(entity);              
                    dtos.Add(dto);
                }
                return dtos;
            }
        }

        public void importData(string path)
        {
            using(var db = new ProjectDbContext())
            {
                StreamReader streamCsv = new StreamReader(path);

                string csvDataLine = "";
                string[] data = null;
                var lineHeader = streamCsv.ReadLine();          
                while ((csvDataLine = streamCsv.ReadLine()) != null)
                {                      
                    data = csvDataLine.Split(',');
                    var newClassType = new ClassType
                    {
                        TypeId = data[0],
                        TeachingTime = data[1]                          
                    };
                    db.ClassTypes.Add(newClassType);
                    db.SaveChanges();                
                }
            }
            
        }

        public List<string> listId()
        {
            List<string> listID = new List<string>();
            using (var db = new ProjectDbContext())
            {
                foreach (var item in db.ClassTypes)
                {
                    listID.Add(item.TypeId.ToString());
                }
                return listID;
            }
        }



    }
}
