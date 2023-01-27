using DepartmentSystemWebAPI.Entities;
using DepartmentSystemWebAPI.GenericDTO;
using DepartmentSystemWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DepartmentSystemWebAPI.Services
{
    public class ExceptionLogServices : IExceptionLogServices
    {
        private readonly DBContext _context;
        public ExceptionLogServices(DBContext dbContext)
        {
            _context = dbContext;

        }
        public async Task<IEnumerable<ExceptionLog>> GetExceptionLog()
        {
            throw new NotImplementedException();
            return await _context.exceptions.ToListAsync();
        }
        public async Task PostException(Exception exception)
        {
            ExceptionLog exceptionLog = new ExceptionLog();
            exceptionLog.message = exception.Message;
            try
            {
                _context.exceptions.Add(exceptionLog);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
           
        }

    }
}
