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
    public class StudentEF : IStudentBusiness
    {
        public void createStudent(StudentDTO newStudent)
        {
            using (var db = new ProjectDbContext())
            {
                var student = DTOEFMapper.GetEntityFromDTO(newStudent);
                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        public void deleteStudent(string studentID)
        {
            using(var db = new ProjectDbContext())
            {
                var student = db.Students.Where(x => x.StudentId == studentID).FirstOrDefault();
                if(student != null)
                {
                    db.Students.Remove(student);
                    db.SaveChanges();
                }
            }
        }

        public List<StudentDTO> findAllStudent()
        {
            List<StudentDTO> students = new List<StudentDTO>();
            using(var db = new ProjectDbContext())
            {
                foreach (var student in db.Students)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(student);
                    students.Add(dto);
                }
                return students;
            }
            
        }

        public StudentDTO findById(string studentID)
        {
            using(var db = new ProjectDbContext())
            {
                var student = db.Students.Where(x => x.StudentId == studentID).FirstOrDefault();
                if(student != null)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(student);
                    return dto;
                }else
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
                    var newStudent = new Student
                    {
                        StudentId = data[0],
                        LastName = data[1],
                        FirstName = data[2],
                        Contact = data[3],
                        BirthDate = Convert.ToDateTime(data[4]),
                        StatusId = data[5]

                    };
                    db.Students.Add(newStudent);
                    db.SaveChanges();
                }
            }
        }

        public List<string> listId()
        {
            List<string> listID = new List<string>();
            using (var db = new ProjectDbContext())
            {
                foreach (var item in db.Students)
                {
                    listID.Add(item.StudentId.ToString());
                }
                return listID;
            }
        }

        public List<StudentDTO> search(string query)
        {
            List<StudentDTO> dtos = new List<StudentDTO>();
            using (var db = new ProjectDbContext())
            {
                var entities = db.Students
                                .Where(e => (e.FirstName .Contains(query) || e.LastName.Contains(query)) || 
                                                string.IsNullOrEmpty(query));
                foreach (var entity in entities)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(entity);
                    dtos.Add(dto);
                }
                return dtos;
            }
        }

        public void updateStudent(StudentDTO updateStudent)
        {
            using(var db = new ProjectDbContext())
            {
                var student = db.Students.Where(x => x.StudentId == updateStudent.StudentId).FirstOrDefault();
                if(student != null)
                {
                    db.Entry(student).CurrentValues.SetValues(updateStudent);
                    db.SaveChanges();
                }
            }
        }
    }
}
