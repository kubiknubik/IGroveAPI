namespace IGrove.Domain.Users.Dtos
{
    public class UserDto
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string PersonalNumber { get; set; }

        public bool IsVerified { get; set; }

        public int StatusId { get; set; }
    }
}
