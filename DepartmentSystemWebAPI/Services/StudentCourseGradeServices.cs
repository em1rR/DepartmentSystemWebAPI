using DepartmentSystemWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentSystemWebAPI.Services
{
    public class StudentCourseGradeServices : IStudentCourseGradeServices
    {
        public Task<string> DeleteStudentCourseGrade(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentCourseGrade>> GetAllData()
        {
            throw new NotImplementedException();
        }

        public Task<StudentCourseGrade> GetStudentCourseGradeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StudentCourseGrade> PostStudentCourseGrade(StudentCourseGrade studentCourseGrade)
        {
            throw new NotImplementedException();
        }

        public Task<string> PutStudentCourseGrade(int id, StudentCourseGrade studentCourseGrade)
        {
            throw new NotImplementedException();
        }
    }
}
