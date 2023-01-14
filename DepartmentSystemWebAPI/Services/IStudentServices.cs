using DepartmentSystemWebAPI.DTO;
using DepartmentSystemWebAPI.Entities;
using DepartmentSystemWebAPI.Filters;
using DepartmentSystemWebAPI.GenericDTO;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentSystemWebAPI.Services
{
    public interface IStudentServices
    {
        //IEnumerable<Student> GetAllStudents();
        Task<IEnumerable<Student>> GetAllData();
        Task<IEnumerable<Student>> GetStudentBySearchNotUsed(StudentFilter studentFilter);
        Task<Student> GetStudentById(int id);
        Task<ApiResponse<Student>> PostStudent(CreateStudentDTO createStudentDTO);
        Task<ApiResponse<EditStudentDTO>> PutStudent(int id, EditStudentDTO editStudentDTO);
        Task<ApiResponse<Student>> DeleteStudent(int id);
        Task<IEnumerable<StudentDTO>> GetAllDataTest();
        //Task<IEnumerable<StudentDTO>> GetStudentBySearchTest(StudentFilter studentFilter);
        Task<ApiResponse<IEnumerable<StudentDTO>>> GetStudentBySearch(StudentFilter studentFilter);
    }
}
