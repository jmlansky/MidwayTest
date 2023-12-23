using Core;
using Helpers;
using Helpers.Contracts;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IHelpers _operationsHelper;
        private readonly IEmployeesRepository _employeesRepository;
        public EmployeesService(IHelpers operationsHelper, IEmployeesRepository employeesRepository)
        {
            _operationsHelper = operationsHelper;
            _employeesRepository = employeesRepository;
        }

        public async Task<string> Insert(Employee employee)
        {
            try
            {
                var existeemployee = await _employeesRepository.GetById(employee.UPN);
                if (existeemployee is not null)
                    return Messages.ERROR_ALREADY_EXISTANT_EMPLOYEE;

                var result = await _employeesRepository.Insert(employee);
                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<Employee> Get()
        {
            var result = _employeesRepository.Get();
            return result;
        }

        public async Task<string> GetBirthdayMessage(string upn)
        {
            var employee = await _employeesRepository.GetById(upn);
            if (employee is null)
                return string.Empty;

            if (employee.IsBirthday(employee.BirthDate))
                return $"¡{Messages.MISC_HAPPY_BIRTHDAY}, {employee.Name}!";

            var diasRestantes = _operationsHelper.CalculateRemainigDaysUntilBirthday(employee.BirthDate);
            return $"{Messages.MISC_ITS_OK}, {Messages.MISC_ONLY_REMAINING} {diasRestantes} {Messages.MISC_DAYS_FOR_YOUR_BURTHDAY}.";
        }

        /// <inheritdoc/>
        public IEnumerable<Employee> GetTeamMembersWithBirthday(string upn, DateTime? date = null)
        {
            var dateToProcess = date ?? DateTime.Today;

            var employees = Get();
            if (!employees.Any())
                return new List<Employee>();

            var teamMembers = GetTeamMembers(employees, upn);
            if (!teamMembers.Any())
                return new List<Employee>();

            employees = teamMembers.Where(x => _operationsHelper.CalculateRemainigDaysUntilBirthday(x.BirthDate) <= 7);
            return employees;
        }


        private List<Employee> GetTeamMembers(IEnumerable<Employee> employees, string loggedInUser)
        {
            var teamMembers = new List<Employee>();

            var employee = employees.FirstOrDefault(x => x.UPN.ToLower() == loggedInUser);
            if (employee is null)
                return new List<Employee>();

            //look for siblings
            var siblings = employees.Where(x => x.ResponsibleUPN == employee.ResponsibleUPN && x.UPN != loggedInUser.ToLower());
            teamMembers.AddRange(siblings);

            //look for children
            var childrensToAdd = GetChildren(employee, employees);
            teamMembers.AddRange(childrensToAdd);

            return teamMembers;
        }

        private List<Employee> GetChildren(Employee employee, IEnumerable<Employee> employees)
        {
            //look for children
            var children = employees.Where(e => e.ResponsibleUPN == employee.UPN);
            if (!children.Any())
                return new List<Employee>();

            var list = new List<Employee>();
            foreach (var child in children)
            {
                list.Add(child);
                var childrensToAdd = GetChildren(child, employees);
                list.AddRange(childrensToAdd);
            }

            return list;
        }
    }
}