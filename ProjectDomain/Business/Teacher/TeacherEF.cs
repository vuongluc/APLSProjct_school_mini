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
    public class TeacherEF : ITeacherBusiness
    {
        public void createTeacher(TeacherDTO newTeacher)
        {
            using (var db = new ProjectDbContext())
            {
                var teacher = DTOEFMapper.GetEntityFromDTO(newTeacher);
                db.Teachers.Add(teacher);
                db.SaveChanges();
            }
        }

        public void deleteTeacher(string teacherID)
        {
            using (var db = new ProjectDbContext())
            {
                var teacher = db.Teachers.Where(m => m.TeacherId == teacherID).FirstOrDefault();
                if (teacher != null)
                {
                    db.Teachers.Remove(teacher);
                    db.SaveChanges();
                }
            }
        }

        public List<TeacherDTO> findAllTeacher()
        {
            using (var db = new ProjectDbContext())
            {
                List<TeacherDTO> teachers = new List<TeacherDTO>();
                foreach (var entity in db.Teachers)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(entity);
                    teachers.Add(dto);
                }
                return teachers;
            }
        }

        public TeacherDTO findById(string teacherID)
        {
            using (var db = new ProjectDbContext())
            {
                var entity = db.Teachers.Where(x => x.TeacherId == teacherID).FirstOrDefault();
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
                    var newTeacher = new Teacher
                    {
                        TeacherId = data[0],
                        LastName = data[1],
                        FirstName = data[2],
                        Contact = data[3],
                        BirthDate = Convert.ToDateTime(data[4]),
                        StatusId = data[5]

                    };
                    db.Teachers.Add(newTeacher);
                    db.SaveChanges();
                }
            }
        }

        public List<string> listId()
        {
            List<string> listID = new List<string>();
            using (var db = new ProjectDbContext())
            {
                foreach (var item in db.Teachers)
                {
                    listID.Add(item.TeacherId.ToString());
                }
                return listID;
            }
        }

        public List<TeacherDTO> search(string query)
        {
            List<TeacherDTO> dtos = new List<TeacherDTO>();
            using (var db = new ProjectDbContext())
            {
                var entities = db.Teachers
                                .Where(e => (e.FirstName.Contains(query) || e.LastName.Contains(query)) ||
                                                string.IsNullOrEmpty(query));
                foreach (var entity in entities)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(entity);
                    dtos.Add(dto);
                }
                return dtos;
            }
        }

        public void updateTeacher(TeacherDTO updateTeacher)
        {
            using (var db = new ProjectDbContext())
            {
                var teacher = db.Teachers.Where(m => m.TeacherId == updateTeacher.TeacherId).FirstOrDefault();
                if (teacher != null)
                {
                    db.Entry(teacher).CurrentValues.SetValues(updateTeacher);
                    db.SaveChanges();
                }
            }
        }
    }
}
