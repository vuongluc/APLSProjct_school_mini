namespace ProjectDomain.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectDbContext : DbContext
    {
        public ProjectDbContext()
            : base("name=ProjectDbContextConnectionString")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Capable> Capables { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassType> ClassTypes { get; set; }
        public virtual DbSet<Enroll> Enrolls { get; set; }
        public virtual DbSet<Evaluate> Evaluates { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.salf)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Capable>()
                .Property(e => e.ModuleId)
                .IsUnicode(false);

            modelBuilder.Entity<Capable>()
                .Property(e => e.TeacherId)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.ClassId)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.ModuleId)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.StatusId)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.TeacherId)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.TypeId)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Enrolls)
                .WithRequired(e => e.Class)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Evaluates)
                .WithRequired(e => e.Class)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassType>()
                .Property(e => e.TypeId)
                .IsUnicode(false);

            modelBuilder.Entity<ClassType>()
                .Property(e => e.TeachingTime)
                .IsUnicode(false);

            modelBuilder.Entity<Enroll>()
                .Property(e => e.StudentId)
                .IsUnicode(false);

            modelBuilder.Entity<Enroll>()
                .Property(e => e.ClassId)
                .IsUnicode(false);

            modelBuilder.Entity<Enroll>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Enroll>()
                .Property(e => e.ExamGrade)
                .IsUnicode(false);

            modelBuilder.Entity<Evaluate>()
                .Property(e => e.StudentId)
                .IsUnicode(false);

            modelBuilder.Entity<Evaluate>()
                .Property(e => e.ClassId)
                .IsUnicode(false);

            modelBuilder.Entity<Evaluate>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Evaluate>()
                .Property(e => e.Understand)
                .IsUnicode(false);

            modelBuilder.Entity<Evaluate>()
                .Property(e => e.Punctuality)
                .IsUnicode(false);

            modelBuilder.Entity<Evaluate>()
                .Property(e => e.Support)
                .IsUnicode(false);

            modelBuilder.Entity<Evaluate>()
                .Property(e => e.Teaching)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.ModuleId)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.ModuleName)
                .IsUnicode(false);


            modelBuilder.Entity<Status>()
                .Property(e => e.StatusId)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.StatusName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.StudentId)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Contact)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.StatusId)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Enrolls)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Evaluates)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.TeacherId)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Contact)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.StatusId)
                .IsUnicode(false);

        }
    }
}
