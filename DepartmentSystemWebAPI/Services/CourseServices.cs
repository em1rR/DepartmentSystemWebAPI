using DepartmentSystemWebAPI.Entities;
using DepartmentSystemWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepartmentSystemWebAPI.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly DBContext _context;
        public CourseServices(DBContext dBContext)
        {
            _context = dBContext;
        }
        //GET
        public async Task<IEnumerable<Course>> GetAllData()
        {
            return await _context.courses.ToListAsync();
        }
        //GET by Id
        public async Task<Course> GetCourseById(int id)
        {
            var course = await _context.courses.FindAsync(id);

            if (course == null)
            {
                return NotFoundResult();

            }

            return course;
        }

        //POST
        public async Task<Course> PostCourse(Course course)
        {
            _context.courses.Add(course);
            await _context.SaveChangesAsync();
            //return CreatedAtAction("GetStudent", new { id = student.id }, student);
            return OkObjectResult(course);
        }

        
        //PUT
        public async Task<String> PutCourse(int id, Course course)
        {
            if (id != course.id)
            {
                return ("bad request");
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return "Not Found";
                }
                else
                {
                    throw;
                }
            }

            return "No Content";
        }
        private Course NotFoundResult()
        {
            throw new NotImplementedException();
        }
        private Course OkObjectResult(Course course)
        {
            throw new NotImplementedException();
        }
        private bool CourseExists(int id)
        {
            return _context.courses.Any(e => e.id == id);
        }


    }
}
