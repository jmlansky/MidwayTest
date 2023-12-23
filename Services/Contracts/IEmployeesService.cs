using Core;

namespace Services.Contracts
{
    public interface IEmployeesService
    {
        Task<string> Insert(Employee empleado);
        IEnumerable<Employee> Get();
        Task<string> GetBirthdayMessage(string upn);


        /// <summary>
        /// Get a list of employees with birthday this week.
        /// </summary>
        /// <param name="upn">Logged user email</param>
        /// <returns>List of employees with birthday date next week from a specific date (today by default)</returns>
        IEnumerable<Employee> GetTeamMembersWithBirthday(string upn, DateTime? date = null);
    }
}
