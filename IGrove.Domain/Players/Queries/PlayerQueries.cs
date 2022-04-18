using IGrove.Domain.Players.Dtos;
using Shared.Utils.Queries;

namespace IGrove.Domain.Players.Queries
{
    public class GetPlayerByIdQuery : QueryBase<PlayerDto>
    {
        public int Id { get; set; }
    }

    public class GetPlayerByUsernameQuery : QueryBase<PlayerDto>
    {
        public string Username { get; set; }
    }
}
