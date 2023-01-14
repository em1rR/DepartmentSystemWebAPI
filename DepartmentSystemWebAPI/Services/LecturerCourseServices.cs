using DepartmentSystemWebAPI.Entities;
using DepartmentSystemWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepartmentSystemWebAPI.Services
{
    public class LecturerCourseServices : ILecturerCourseServices
    {
        private readonly DBContext _context;

        public LecturerCourseServices(DBContext dBContext)
        {
            _context = dBContext;
        }

        public async Task<IEnumerable<LecturerCourse>> GetAllData()
        {
            return await _context.lecturer_courses.ToListAsync();
        }
    }
}
