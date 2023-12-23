using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Employee
    {
        [Key]
        [EmailAddress]
        public string UPN { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public string ResponsibleUPN { get; set; }
        public Employee Responsible { get; set; }

        public bool IsBirthday(DateTime birthday)
        {
            var currentDate = DateTime.Now;
            return birthday.Day == currentDate.Day && birthday.Month == currentDate.Month;
        }
    }
}