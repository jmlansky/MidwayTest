using Core;

namespace Repositories.Contracts
{
    public interface IEmployeesRepository
    {
        IEnumerable<Employee> Get();
        Task<Employee> GetById(string upn);        
        Task<bool> Insert(Employee empleado);
    }
}
