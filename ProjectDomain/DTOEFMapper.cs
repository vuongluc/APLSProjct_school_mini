using AutoMapper;
using ProjectDomain.DTOs;
using ProjectDomain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain
{
    public class DTOEFMapper
    {
        //ClassType
        public static ClassType GetEntityFromDTO(ClassTypesDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<ClassTypesDTO, ClassType>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<ClassTypesDTO, ClassType>(dto);
        }

        public static ClassTypesDTO GetDtoFromEntity(ClassType entity)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<ClassType, ClassTypesDTO>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<ClassType, ClassTypesDTO>(entity);
        }

        //Status
        public static Status GetEntityFromDTO(StatusDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<StatusDTO, Status>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<StatusDTO, Status>(dto);
        }

        public static StatusDTO GetDtoFromEntity(Status entity)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<Status, StatusDTO>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<Status, StatusDTO>(entity);
        }
        // Module
        public static Module GetEntityFromDTO(ModuleDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<ModuleDTO, Module>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<ModuleDTO, Module>(dto);
        }

        public static ModuleDTO GetDtoFromEntity(Module entity)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<Module, ModuleDTO>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<Module, ModuleDTO>(entity);
        }

        // Teacher
        public static Teacher GetEntityFromDTO(TeacherDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<TeacherDTO, Teacher>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<TeacherDTO, Teacher>(dto);
        }

        public static TeacherDTO GetDtoFromEntity(Teacher entity)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<Teacher, TeacherDTO>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<Teacher, TeacherDTO>(entity);
        }

        // Student
        public static Student GetEntityFromDTO(StudentDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<StudentDTO, Student>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<StudentDTO, Student>(dto);
        }

        public static StudentDTO GetDtoFromEntity(Student entity)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<Student, StudentDTO>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<Student, StudentDTO>(entity);
        }
        // Class

        public static Class GetEntityFromDTO(ClassDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<ClassDTO, Class>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<ClassDTO, Class>(dto);
        }

        public static ClassDTO GetDtoFromEntity(Class entity)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<Class, ClassDTO>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<Class, ClassDTO>(entity);
        }

        // Enroll
        public static Enroll GetEntityFromDTO(EnrollDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<EnrollDTO, Enroll>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<EnrollDTO, Enroll>(dto);
        }

        public static EnrollDTO GetDtoFromEntity(Enroll entity)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<Enroll, EnrollDTO>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<Enroll, EnrollDTO>(entity);
        }
        // Capable

        public static Capable GetEntityFromDTO(CapableDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<CapableDTO, Capable>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<CapableDTO, Capable>(dto);
        }

        public static CapableDTO GetDtoFromEntity(Capable entity)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<Capable, CapableDTO>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<Capable, CapableDTO>(entity);
        }

        // Evaluate
        public static Evaluate GetEntityFromDTO(EvaluateDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<EvaluateDTO, Evaluate>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<EvaluateDTO, Evaluate>(dto);
        }

        public static EvaluateDTO GetDtoFromEntity(Evaluate entity)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<Evaluate, EvaluateDTO>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<Evaluate, EvaluateDTO>(entity);
        }

            

        //Login

        public static Account GetEntityFromDTO(AccountDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<AccountDTO, Account>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<AccountDTO, Account>(dto);
        }

        public static AccountDTO GetDtoFromEntity(Account entity)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<Account, AccountDTO>());
            IMapper mapper = new Mapper(config);
            return mapper.Map<Account, AccountDTO>(entity);
        }
    }
}
