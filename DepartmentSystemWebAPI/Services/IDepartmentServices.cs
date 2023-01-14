using DepartmentSystemWebAPI.Entities;

namespace DepartmentSystemWebAPI.Services
{
    public interface IDepartmentServices
    {
        Task<IEnumerable<Department>> GetAllData();
    }
}
