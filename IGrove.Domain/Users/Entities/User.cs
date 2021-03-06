using Shared.Utils.Entities;

namespace IGrove.Domain.Users.Entities
{
    public class User : IEntityIdentifier<long>
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Passord { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string PersonalNumber { get; set; }

        public bool IsVerified { get; set; }

        public int StatusId { get; set; }
    }
}
