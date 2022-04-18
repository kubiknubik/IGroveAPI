using IGrove.Domain.Users.Entities;
using IGrove.Domain.Users.Repositories;
using Shared.Utils.Extensions;
using Shared.Utils.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace IGrove.Management.Users.Repositories
{
    public class UserRepository : BaseListRepository<User, long>, IUserReadRepository, IUserWriteRepository
    {
        public UserRepository()
        {
            _data.Add(new User
            {
                Id = 1,
                Email = "user@gmail.com",
                Username = "user@gmail.com",
                FirstName = "Vasiko",
                LastName = "Maisuradze",
                IsVerified = false,
                Passord = "vaso123".HashPassword("user@gmail.com"),
                PersonalNumber = "01005030963"
            });
        }

        public Task<User> GetByName(string name, CancellationToken cancellationToken)
        {
            var result = GetBy(x => x.Username == name, cancellationToken);

            return Task.FromResult(result);
        }

        public Task<User> GetByPhone(string phone, CancellationToken cancellationToken)
        {
            var result =  GetBy(x => x.PhoneNumber == phone, cancellationToken);

            return Task.FromResult(result);
        }
    }
}