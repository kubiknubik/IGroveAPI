using IGrove.Domain.Users.Dtos;
using Shared.Utils.Queries;

namespace IGrove.Domain.Users.Queries
{
    public class GetUserAuthenticationQuery : QueryBase<UserDto>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
