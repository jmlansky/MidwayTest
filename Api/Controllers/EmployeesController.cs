using Api.Dtos;
using Api.Requests;
using Api.Responses;
using Auth.Contracts;
using Core;
using Helpers;
using Helpers.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployeesService _usuariosService;

        private readonly IHelpers _helpers;
        public EmployeesController(IHelpers helpers, IEmployeesService usuariosService)
        {
            _usuariosService = usuariosService;
            _helpers = helpers;            
        }

        
        [HttpGet("birthday/{upn}")]
        public async Task<IActionResult> Birthday(string upn)
        {
            var mensaje = await _usuariosService.GetBirthdayMessage(upn);
            if (string.IsNullOrEmpty(mensaje))
                return NotFound($"{Messages.ERROR_EMPLOYEE_NOT_FOUND}: {upn}");

            return Ok(new BirthdayMessageResponse() { Mensaje = mensaje });
        }

        [HttpGet("birthday/team")]
        public IActionResult BirthdayTeam(string upn)
        {
            var employees = _usuariosService.GetTeamMembersWithBirthday(upn);

            var response = employees.Select(x => new BirthdayMemberTeamDTO() 
            {
                BirthDate = x.BirthDate.ToString(Messages.MISC_BIRTHDAY_FORMAT),
                LastName = x.LastName,
                Name = x.Name,
                UPN = upn
            });
            return Ok(new TeamBirthdayResponse() { Employees = response });
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var result = _usuariosService.Get();
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostEmployeeRequest request)
        {
            if (! _helpers.IsValidDateFormat(request.Employee.BirthDate))
                return BadRequest($"{Messages.ERROR_DATE_FORMAT} {Messages.MISC_DAYS_FORMAT}");
                        
            var employee = new Employee()
            {
                UPN = request.Employee.UPN.ToLower(),
                Name = request.Employee.Name,
                LastName = request.Employee.LastName,
                BirthDate = Convert.ToDateTime(request.Employee.BirthDate),
                ResponsibleUPN = request.Employee.ResponsibleUPN,
            };

            var result = await _usuariosService.Insert(employee);
            return Ok(result);
        }

    }
}
