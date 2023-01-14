using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DepartmentSystemWebAPI.Entities;
using DepartmentSystemWebAPI.Models;
using DepartmentSystemWebAPI.Services;
using DepartmentSystemWebAPI.Filters;
using DepartmentSystemWebAPI.DTO;
using DepartmentSystemWebAPI.Enums;
using DepartmentSystemWebAPI.KeyValuePair;
using DepartmentSystemWebAPI.GenericDTO;
using DepartmentSystemWebAPI.Exceptions;

namespace DepartmentSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        //private readonly StudentContext _context;
        //private readonly StudentServices _studentServices;
        private IStudentServices _studentServices;
        private ICourseServices _courseServices;
        private ILecturerServices _lecturerServices;
        private ILecturerCourseServices _lecturer_courseServices;
        private IDepartmentServices _departmentServices;
        private IGraduateServices _graduateServices;

        //public StudentsController(StudentContext context)
        //{
        //    _context = context;
        //}
        public AppController(IStudentServices studentServices, ICourseServices courseServices, ILecturerServices lecturerServices, ILecturerCourseServices lecturer_CourseServices, IDepartmentServices departmentServices, IGraduateServices graduateServices)
        {
            _studentServices = studentServices;
            _courseServices = courseServices;
            _lecturerServices = lecturerServices;
            _lecturer_courseServices = lecturer_CourseServices;
            _departmentServices = departmentServices;
            _graduateServices = graduateServices;
        }

        #region students

        //GET: api/Students
        [HttpGet]
        [Route("Student/Get")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            throw new Test();
            return await _studentServices.GetAllData();
        }

        [HttpGet]
        [Route("StudentDto/Get")]
        public async Task<IEnumerable<StudentDTO>> GetStudentsDto()
        {
            return await _studentServices.GetAllDataTest();
        }

        // GET: api/Students/5
        [HttpGet]
        [Route("Student/Get{id}")]
        public async Task<Student> GetStudent(int id)
        {
            try
            {
                return await _studentServices.GetStudentById(id);
            }
            catch (Exception)
            {

                return new Student();
            }
        }


        //GET: api/Students
        [HttpGet]
        [Route("Student/GetBySearch")]
        //public async Task<IEnumerable<Student>> GetBySearch(string id, string name, string department_id, string graduate_id)
        public async Task<IEnumerable<Student>> GetBySearch([FromQuery]StudentFilter studentFilter)
        {
            //StudentFilter studentFilter = new StudentFilter();
            //studentFilter.Name = name;
            //studentFilter.Id = int.Parse(id);
            //studentFilter.GraduateId = int.Parse(graduate_id);
            //studentFilter.DepartmentId = int.Parse(graduate_id);

            var q = await _studentServices.GetStudentBySearch(studentFilter);
            return q;
            //return await _studentRepository.GetStudentBySearch();
        }

        //GET: api/Students
        [HttpGet]
        [Route("Student/GetBySearchTest")]
        //public async Task<IEnumerable<Student>> GetBySearch(string id, string name, string department_id, string graduate_id)
        public async Task<ApiResponse<IEnumerable<StudentDTO>>> GetBySearchTest([FromQuery] StudentFilter studentFilter)
        {
            //StudentFilter studentFilter = new StudentFilter();
            //studentFilter.Name = name;
            //studentFilter.Id = int.Parse(id);
            //studentFilter.GraduateId = int.Parse(graduate_id);
            //studentFilter.DepartmentId = int.Parse(graduate_id);

            
            var apiResponse = await _studentServices.GetStudentBySearchTest(studentFilter);
            return apiResponse;

        }


        //PUT: api/Students/5
        [HttpPut]
        [Route("Student/Put{id}")]
        public async Task<ApiResponse<EditStudentDTO>> PutStudent(int id, EditStudentDTO student)
        {
            return await _studentServices.PutStudent(id, student);
        }

        //POST: api/Students
        [HttpPost]
        [Route("Student/Post")]
        //public async Task<Student> PostStudent(CreateStudentDTO student)
        public async Task<ApiResponse<Student>> PostStudent(CreateStudentDTO student)
        {
            return await _studentServices.PostStudent(student);
            //try
            //{
               
            //}
            //catch (Exception ex)
            //{
            //    //throw ex;
            //    return new ApiResponse<Student>();
            //    //return ex;
            //}
           
        }

        //DELETE
        [HttpDelete]
        [Route("Student/Delete{id}")]
        public async Task<ApiResponse<Student>> DeleteStudent(int id)
        {
            return await _studentServices.DeleteStudent(id);
        }

        #endregion

        #region coursesend

        //GET: api/Courses
        [HttpGet]
        [Route("Course/Get")]
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _courseServices.GetAllData();
        }

        //GET: api/Course/5
        [HttpGet]
        [Route("Course/Get{id}")]
        public async Task<Course> GetCourse(int id)
        {
            return await _courseServices.GetCourseById(id);
        }

        //Put: api/Course
        [HttpPut]
        [Route("Course/Put{id}")]
        public async Task<String> PutCourse(int id, Course course)
        {
            return await _courseServices.PutCourse(id, course);
        }

        //POST: api/Course
        [HttpPost]
        [Route("Course/Post")]
        public async Task<Course> PostCourse(Course course)
        {
            return await _courseServices.PostCourse(course);
        }

        #endregion

        #region lecturers

        //GET: api/Lecturers
        [HttpGet]
        [Route("Lecturer/Get")]
        public async Task<IEnumerable<Lecturer>> GetLecturers()
        {
            return await _lecturerServices.GetAllData();
        }

        //GET: api/Lecturer/5
        [HttpGet]
        [Route("Lecturer/Get{id}")]
        public async Task<Lecturer> GetLecturer(int id)
        {
            return await _lecturerServices.GetLecturerById(id);
        }

        //Put: api/Lecturer
        [HttpPut]
        [Route("Lecturer/Put{id}")]
        public async Task<String> PutLecturer(int id, Lecturer lecturer)
        {
            return await _lecturerServices.PutLecturer(id, lecturer);
        }

        //POST: api/Lecturer
        [HttpPost]
        [Route("Lecturer/Post")]
        public async Task<Lecturer> PostLecturer(Lecturer lecturer)
        {
            return await _lecturerServices.PostLecturer(lecturer);
        }


        [HttpDelete]
        [Route("Lecturer/Delete")]
        public async Task<String> DeleteLecturer(int id)
        {
            return await _lecturerServices.DeleteLecturer(id);
        }

        #endregion

        #region lecturerCourses

        //GET: api/Lecturer_Courses
        [HttpGet]
        [Route("Lecturer_Courses/Get")]
        public async Task<IEnumerable<LecturerCourse>> GetLecturer_Courses()
        {
            return await _lecturer_courseServices.GetAllData();
        }

        #endregion

        #region department

        //GET: api/Departments
        [HttpGet]
        [Route("Department/Get")]
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _departmentServices.GetAllData();
        }

        #endregion

        #region graduate

        //GET: api/Graduates
        [HttpGet]
        [Route("Graduate/Get")]
        public async Task<IEnumerable<Graduate>> GetGraduate()
        {
            return await _graduateServices.GetAllData();
        }

        #endregion

        #region gender
        //GET: api/Gender
        [HttpGet]
        [Route("Gender/Get")]
        public async Task<List<DropDownGenderModel>> GetGender([FromQuery] string type)
        {
            //Dictionary<string, byte> genderDictionary = ((Gender[])Enum.GetValues(typeof(Gender))).ToDictionary(k => k.ToString(), v => (byte)v);

            //return genderDictionary;
            switch (type)
            {
                case "search":
                    var a = DropDownListMethod.MakeSearchList();
                    return a;
                case "add":
                    return DropDownListMethod.MakeCreateList();
                default: return new List<DropDownGenderModel> { };
            }

        }
        #endregion


    }
}
