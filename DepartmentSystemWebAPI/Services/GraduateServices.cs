using DepartmentSystemWebAPI.Entities;
using DepartmentSystemWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DepartmentSystemWebAPI.Services
{
    public class GraduateServices : IGraduateServices
    {
        private readonly DBContext _context;
        public GraduateServices(DBContext dBContext)
        {
            _context = dBContext;
        }

        public async Task<IEnumerable<Graduate>> GetAllData()
        {
            return await _context.graduates.ToListAsync();
        }
    }
}
