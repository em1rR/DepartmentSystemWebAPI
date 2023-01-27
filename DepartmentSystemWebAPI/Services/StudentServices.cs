using DepartmentSystemWebAPI.DTO;
using DepartmentSystemWebAPI.Entities;
using DepartmentSystemWebAPI.Filters;
using DepartmentSystemWebAPI.GenericDTO;
using DepartmentSystemWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepartmentSystemWebAPI.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly DBContext _context;
        public StudentServices(DBContext context)
        {
            _context = context;
        }
        // GET all students
        public async Task<IEnumerable<Student>> GetAllData()
        {
            return await _context.students.ToListAsync();
        }
        // GET by Id
        public async Task<Student> GetStudentById(int id)
        {
            var student = await _context.students.FindAsync(id);

            if (student == null)
            {
               //validation
            }

            return student;
        }

        public async Task<IEnumerable<Student>> GetStudentBySearchNotUsed(StudentFilter studentFilter)
        {
            var result = _context.students.Where(x=> x.name.Contains(studentFilter.Name) || x.graduate_id == studentFilter.GraduateId).ToList();

            IQueryable<Student> query = _context.students;

            if (studentFilter.Id != 0)
            {
                query = query.Where(x => x.id == studentFilter.Id);
            }
            if (studentFilter.Name != "q")
            {
                query = query.Where(x => x.name.Contains(studentFilter.Name));
            }
            if (studentFilter.GraduateId != 0)
            {
                query = query.Where(x => x.graduate_id == studentFilter.GraduateId);
            }
            if (studentFilter.DepartmentId != 0)
            {
                query = query.Where(x => x.department_id == studentFilter.DepartmentId);
            }

            var queryResult = await query.ToListAsync();


            return queryResult;
        }
        // GET student by search
        public async Task<ApiResponse<IEnumerable<StudentDTO>>> GetStudentBySearch(StudentFilter studentFilter)
        {
            var query =

               (from s in _context.students
               join d in _context.departments on s.department_id equals d.id
               join g in _context.graduates on s.graduate_id equals g.id
               select new { s, d, g });

            query = query.Where(x => x.s.is_deleted == false);

            if (studentFilter.Id != 0)
            {
                query = query.Where(x => x.s.id == studentFilter.Id);
            }
            if (studentFilter.Name != "q")
            {
                query = query.Where(x => x.s.name.Contains(studentFilter.Name));
            }
            if (studentFilter.GraduateId != 0)
            {
                query = query.Where(x => x.s.graduate_id == studentFilter.GraduateId);
            }
            if (studentFilter.DepartmentId != 0)
            {
                query = query.Where(x => x.s.department_id == studentFilter.DepartmentId);
            }
            if (studentFilter.Gender != 0)
            {
                query = query.Where(x => x.s.gender == studentFilter.Gender);
            }

            try
            {
                var listDto = from x in query
                              select new StudentDTO
                              {
                                  id = x.s.id,
                                  name = x.s.name,
                                  departmentName = x.d.name,
                                  department_id = x.s.department_id,
                                  graduate_id = x.s.graduate_id,
                                  graduateName = x.g.name,
                                  gender = ((Enums.Gender)x.s.gender).ToString(),
                                  isDeleted = x.s.is_deleted
                              };
                ApiResponse<IEnumerable<StudentDTO>> apiResponse = new ApiResponse<IEnumerable<StudentDTO>>();
                apiResponse.Data = listDto;
                apiResponse.Status = true;
                apiResponse.Message = "Listed Succesfully";
                return apiResponse;
            }
            catch (Exception)
            {

                throw;
            }


            return new ApiResponse<IEnumerable<StudentDTO>>();
        }

        // POST
        public async Task<ApiResponse<Student>> PostStudent(CreateStudentDTO createStudentDTO)
        {
            //todo: validation
            if(!StudentExists(createStudentDTO.Id))
            {

                ApiResponse<Student> response = new ApiResponse<Student>();
                Student student = new Student();
                student.id = createStudentDTO.Id;
                student.name = createStudentDTO.Name;
                student.department_id = createStudentDTO.DepartmentId;
                student.graduate_id = createStudentDTO.GraduateId;
                student.gender = createStudentDTO.Gender;
                student.create_date = DateTime.UtcNow;
                try
                {
                    _context.students.Add(student);
                    await _context.SaveChangesAsync();
                    response.Status = true;
                    response.Message = "Student Added Succesfully";
                    response.Data = student;
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Message = ex.Message;
                    throw;
                }
        
                return response;
            }
            else
            {
                return new ApiResponse<Student>{ Message = "Student allready exist."};
            }
            
        }

        // PUT
        public async Task<ApiResponse<EditStudentDTO>> PutStudent(int id, EditStudentDTO editStudentDTO)
        {
            ApiResponse<EditStudentDTO> response = new ApiResponse<EditStudentDTO>();

            var oldobj = _context.students.Where(x => x.id == id).SingleOrDefault();
            if (oldobj != null)
            {
                //oldobj.id = editStudentDTO.Id;
                oldobj.name = editStudentDTO.Name;
                oldobj.department_id = editStudentDTO.DepartmentId;
                oldobj.graduate_id = editStudentDTO.GraduateId;
                oldobj.gender = editStudentDTO.Gender;
                oldobj.update_date = DateTime.UtcNow;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Message = "Something went wrong while saving";
                    response.Data = null;
                }

                response.Status = true;
                response.Message = "Edited Succesfully";
                response.Data = null;

            }
            else
            {
                response.Status = false;
                response.Message = "Not found";
                response.Data = null;
            }

            return response;
        }

        //DELETE
        public async Task<ApiResponse<Student>> DeleteStudent(int id)
        {
            ApiResponse<Student> response = new ApiResponse<Student>();
            if (StudentExists(id))
            {
                var student = await _context.students.FindAsync(id);
                student.delete_date = DateTime.UtcNow;
                student.is_deleted = true;
                _context.Attach(student).Property(x => x.is_deleted).IsModified = true;
                await _context.SaveChangesAsync();

                response.Status = true;
                response.Message = "Deleted Succesfully";
                response.Data = null;
            }
            else
            {
                response.Status = false;
                response.Message = "Student not exist";
                response.Data = null;
            }

            return response;
        }

        // GET all students
        public async Task<IEnumerable<StudentDTO>> GetAllDataTest()
        {
            var query =
               from s in _context.students
               join d in _context.departments on s.department_id equals d.id
               join g in _context.graduates on s.graduate_id equals g.id
               //     where s.department_id == d..ID == id
               select new StudentDTO
               {
                   id = s.id,
                   name = s.name,
                   departmentName = d.name,
                   department_id = s.department_id,
                   graduate_id = s.graduate_id,
                   graduateName = g.name,
               };
            var listDto = query.ToList();
 
            return listDto;
        }
   
        private bool StudentExists(int id)
        {
            return _context.students.Any(e => e.id == id);
        }

    }
}
