using Helpers;
using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class EmployeeDto
    {
        [Required(ErrorMessage = Messages.ERROR_EMAIL_REQUIRED)]
        [EmailAddress(ErrorMessage = Messages.ERROR_EMAIL_INVALID)]
        public string UPN { get; set; }

        [Required(ErrorMessage = Messages.ERROR_NAME_REQUIRED)]
        public string Name { get; set; }

        [Required(ErrorMessage = Messages.ERROR_LAST_NAME_REQUIRED)]
        public string LastName { get; set; }

        [Required(ErrorMessage = $"{Messages.ERROR_BIRTHDATE_REQUIRED} ({Messages.MISC_DAYS_FORMAT})")]
        public string BirthDate { get; set; }
        public string ResponsibleUPN { get; set; }
    }
}
