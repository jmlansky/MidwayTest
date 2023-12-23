using Api.Dtos;

namespace Api.Responses
{
    public class TeamBirthdayResponse
    {
        public IEnumerable<BirthdayMemberTeamDTO> Employees { get; set; }
    }
}
