namespace Helpers.Contracts
{
    public interface IHelpers
    {
        int CalculateRemainigDaysUntilBirthday(DateTime birthDate);

        //bool IsBirthdayWeek(DateTime birthday);
        bool IsValidDateFormat(string date);
    }
}
