using DepartmentSystemWebAPI.Entities;
using DepartmentSystemWebAPI.Enums;
using Microsoft.EntityFrameworkCore;

namespace DepartmentSystemWebAPI.Models
{
    public class DBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DBContext(IConfiguration configuration)
        {
            Configuration = configuration; 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<LecturerCourse>().HasKey(table => new
            {
                table.lecturer_id,
                table.course_id
            });

            builder.Entity<StudentCourseGrade>().HasKey(table => new
            {
                table.student_id,
                table.course_id
            });
        }

        public DbSet<Student> students { get; set; } = null!;
        public DbSet<Lecturer> lecturers { get; set; } = null!;
        public DbSet<Course> courses { get; set; } = null!;
        public DbSet<Department> departments { get; set; } = null!;
        public DbSet<Graduate> graduates { get; set; } = null!;
        public DbSet<StudentCourseGrade> student_course_grades { get; set; } = null!;
        public DbSet<LecturerCourse> lecturer_courses { get; set; } = null!;
        public DbSet<ExceptionLog> exceptions { get; set; } = null!;

    }
}
