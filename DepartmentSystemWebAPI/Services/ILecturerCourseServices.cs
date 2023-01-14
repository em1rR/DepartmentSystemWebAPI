using DepartmentSystemWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentSystemWebAPI.Services
{
    public interface ILecturerCourseServices
    {
        Task<IEnumerable<LecturerCourse>> GetAllData();
    }
}
