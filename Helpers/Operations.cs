using Helpers.Contracts;
using System.Globalization;

namespace Helpers
{
    public class Operations : IHelpers
    {
        public int CalculateRemainigDaysUntilBirthday(DateTime birthDate)
        {
            var currentDate = DateTime.Now;
            var nextBirthday = new DateTime(currentDate.Year, birthDate.Month, birthDate.Day);

            if (nextBirthday < currentDate)
                nextBirthday = nextBirthday.AddYears(1);

            return (nextBirthday - currentDate).Days +1;
        }

        //public bool IsBirthdayWeek(DateTime birthday)
        //{
        //    var fechaActual = DateTime.Now;
        //    var proximoCumpleaños = new DateTime(fechaActual.Year, fechaNacimiento.Month, fechaNacimiento.Day);

        //    if (proximoCumpleaños < fechaActual)
        //        proximoCumpleaños = proximoCumpleaños.AddYears(1);

        //    return (proximoCumpleaños - fechaActual).Days + 1;
        //}

        public bool IsValidDateFormat(string date)
        {
            return DateTime.TryParseExact(date.Trim(), "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }
    }
}
