using DepartmentSystemWebAPI.Entities;
using DepartmentSystemWebAPI.GenericDTO;

namespace DepartmentSystemWebAPI.Services
{
    public interface IExceptionLogServices
    {
        Task<IEnumerable<ExceptionLog>> GetExceptionLog();
        Task PostException(Exception exception);
    }
}