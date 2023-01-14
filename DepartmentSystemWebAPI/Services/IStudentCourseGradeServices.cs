using DepartmentSystemWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentSystemWebAPI.Services
{
    public interface IStudentCourseGradeServices
    {
        Task<IEnumerable<StudentCourseGrade>> GetAllData();
        Task<StudentCourseGrade> GetStudentCourseGradeById(int id);
        Task<StudentCourseGrade> PostStudentCourseGrade(StudentCourseGrade studentCourseGrade);
        Task<String> PutStudentCourseGrade(int id, StudentCourseGrade studentCourseGrade);
        Task<String> DeleteStudentCourseGrade(int id);
    }
}
