using DepartmentSystemWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentSystemWebAPI.Services
{
    public interface ICourseServices
    {
        Task<IEnumerable<Course>> GetAllData();
        Task<Course> GetCourseById(int id);
        Task<Course> PostCourse(Course course);
        Task<String> PutCourse(int id, Course course);
    }
}
