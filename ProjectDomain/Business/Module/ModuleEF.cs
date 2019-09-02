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
    public class ModuleEF : IModuleBusiness
    {
        public void createModule(ModuleDTO newModule)
        {
            using (var db = new ProjectDbContext())
            {
                var module = DTOEFMapper.GetEntityFromDTO(newModule);
                db.Modules.Add(module);
                db.SaveChanges();
            }
        }

        public void deleteModule(string moduleID)
        {
            using (var db = new ProjectDbContext())
            {
                var module = db.Modules.Where(m => m.ModuleId == moduleID).FirstOrDefault();
                if (module != null)
                {
                    db.Modules.Remove(module);
                    db.SaveChanges();
                }
            }
        }

        public List<ModuleDTO> findAllModule()
        {
            using (var db = new ProjectDbContext())
            {
                List<ModuleDTO> modules = new List<ModuleDTO>();
                foreach (var entity in db.Modules)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(entity);
                    modules.Add(dto);
                }
                return modules;
            }
        }

        public ModuleDTO findById(string moduleID)
        {
            using (var db = new ProjectDbContext())
            {
                var entity = db.Modules.Where(x => x.ModuleId == moduleID).FirstOrDefault();
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
                    var newModule = new Module
                    {
                        ModuleId = data[0],
                        Duration = Convert.ToByte(data[1]),
                        ModuleName = data[2],
                        Homework = Convert.ToByte(data[3])

                    };
                    db.Modules.Add(newModule);
                    db.SaveChanges();
                }
            }
        }

        public List<string> listId()
        {
            List<string> listID = new List<string>();
            using (var db = new ProjectDbContext())
            {
                foreach (var item in db.Modules)
                {
                    listID.Add(item.ModuleId.ToString());
                }
                return listID;
            }
        }


        public List<ModuleDTO> search(string query)
        {
            List<ModuleDTO> dtos = new List<ModuleDTO>();
            using (var db = new ProjectDbContext())
            {
                var entities = db.Modules
                                .Where(e => e.ModuleName.Contains(query) ||
                                                string.IsNullOrEmpty(query));
                foreach (var entity in entities)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(entity);
                    dtos.Add(dto);
                }
                return dtos;
            }
        }

        public void updateModule(ModuleDTO updateModule)
        {
            using (var db = new ProjectDbContext())
            {
                var module = db.Modules.Where(m => m.ModuleId == updateModule.ModuleId).FirstOrDefault();
                if (module != null)
                {
                    db.Entry(module).CurrentValues.SetValues(updateModule);
                    db.SaveChanges();
                }
            }
        }
    }
}
