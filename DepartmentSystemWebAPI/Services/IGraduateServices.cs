using DepartmentSystemWebAPI.Entities;

namespace DepartmentSystemWebAPI.Services
{
    public interface IGraduateServices
    {
        Task<IEnumerable<Graduate>> GetAllData();
    }
}
