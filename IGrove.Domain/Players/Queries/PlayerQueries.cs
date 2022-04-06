using IGrove.Domain.Players.Dtos;
using Shared.Utils.Queries;

namespace IGrove.Domain.Players.Queries
{
    public class GetPlayerByIdQuery : BaseQuery<PlayerDto>
    {
        public int Id { get; set; }
    }

    public class GetPlayerByUsernameQuery : BaseQuery<PlayerDto>
    {
        public string Username { get; set; }
    }

    public class GetPlayerByPhoneQuery : BaseQuery<PlayerDto>
    {
        public string Phone { get; set; }
    }
}
