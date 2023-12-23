using Core;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly AppDbContext _context;
        public EmployeesRepository(AppDbContext context)
        {       
            _context = context;
        }

        public IEnumerable<Employee> Get()
        {
            return _context.Employees;
        }

        public async Task<Employee> GetById(string upn)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.UPN.ToLower().Equals(upn.ToLower()));
        }

        public async Task<bool> Insert(Employee empleado)
        {
            try
            {
                _context.Employees.Add(empleado);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR - REPOSITORY - INSERT EMPLOYEE: {ex.Message}");
                throw;
            }            
        }
    }
}