using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomain.DTOs;
using ProjectDomain.EF;
using System.IO;

namespace ProjectDomain.Business.Enroll
{
    public class EnrollEF : IEnrollBusiness
    {
        public void createEnroll(EnrollDTO newEnroll)
        {
            using (var db = new ProjectDbContext())
            {
                var enroll = DTOEFMapper.GetEntityFromDTO(newEnroll);
                db.Enrolls.Add(enroll);
                db.SaveChanges();
            }
        }

        public void deleteEnroll(string studentID)
        {
            using (var db = new ProjectDbContext())
            {
                var enroll = db.Enrolls.Where(x => x.StudentId+x.ClassId == studentID).FirstOrDefault();
                if (enroll != null)
                {
                    db.Enrolls.Remove(enroll);
                    db.SaveChanges();
                }
            }
        }

        public List<EnrollDTO> findAllEnroll()
        {
            List<EnrollDTO> enrolls = new List<EnrollDTO>();
            using (var db = new ProjectDbContext())
            {
                foreach (var enroll in db.Enrolls)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(enroll);
                    enrolls.Add(dto);
                }
                return enrolls;
            }
        }

        public EnrollDTO findById(string enrollID)
        {
            using (var db = new ProjectDbContext())
            {
                var enroll = db.Enrolls.Where(x => x.StudentId + x.ClassId == enrollID).FirstOrDefault();
                if (enroll != null)
                {
                    var dto = DTOEFMapper.GetDtoFromEntity(enroll);
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
                    var newEnreoll = new EnrollDTO
                    {
                        StudentId = data[0],
                        ClassId = data[1],
                        Passed = Convert.ToInt32(data[2]),
                        Hw1Grade = Convert.ToDouble(data[3]),
                        Hw2Grade = Convert.ToDouble(data[4]),
                        Hw3Grade = Convert.ToDouble(data[5]),
                        Hw4Grade = Convert.ToDouble(data[6]),
                        Hw5Grade = Convert.ToDouble(data[7]),
                        ExamGrade = data[8]

                    };
                    var dto = DTOEFMapper.GetEntityFromDTO(newEnreoll);
                    db.Enrolls.Add(dto);
                    db.SaveChanges();
                }
            }
        }

        public List<string> listId()
        {
            List<string> listID = new List<string>();
            using (var db = new ProjectDbContext())
            {
                foreach (var item in db.Enrolls)
                {
                    listID.Add(item.StudentId.ToString() + item.ClassId.ToString());
                }
                return listID;
            }
        }

        public List<EnrollDTO> search(string query)
        {
            List<EnrollDTO> dtos = new List<EnrollDTO>();
            using (var db = new ProjectDbContext())
            {
                var entities = db.Enrolls
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

        public void updateEnroll(EnrollDTO updateEnroll)
        {
            using (var db = new ProjectDbContext())
            {
                var student = db.Enrolls.Where(x => x.StudentId + x.ClassId == updateEnroll.StudentId + updateEnroll.ClassId).FirstOrDefault();
                if (student != null)
                {
                    db.Entry(student).CurrentValues.SetValues(updateEnroll);
                    db.SaveChanges();
                }
            }
        }
    }
}
