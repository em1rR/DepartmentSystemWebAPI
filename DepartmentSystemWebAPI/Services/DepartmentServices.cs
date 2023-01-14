using DepartmentSystemWebAPI.Entities;
using DepartmentSystemWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DepartmentSystemWebAPI.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly DBContext _context; 
        public DepartmentServices(DBContext dBContext)
        {
            _context = dBContext;
        }

        public async Task<IEnumerable<Department>> GetAllData()
        {
            return await _context.departments.ToListAsync();
        }
    }
}
