using Shared.Utils.Commands;

namespace IGrove.Domain.Users.Commands
{
    public class RegisterUserCommand : CommandBase
    {
        public string PhoneNumber { get; set; }
    }

    public class VerifyUserPhoneCommand : CommandBase
    {
        public long UserId { get; set; }

        public string Code { get; set; }
    }

    public class VerifyUserPersonalIdCommand : CommandBase
    {
        public long Id { get; set; }
    }
}
