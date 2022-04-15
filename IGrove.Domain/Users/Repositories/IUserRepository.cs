using IGrove.Domain.Users.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace IGrove.Domain.Users.Repositories
{
    public interface IUserReadRepository
    {
        Task<User> GetUserById(int id, CancellationToken cancellationToken);

        Task<User> GetUserByName(string name, CancellationToken cancellationToken);

        Task<User> GetUserByPhone(string phone, CancellationToken cancellationToken);
    }

    public interface IUserWriteRepository
    {
        Task Add(User user, CancellationToken cancellationToken);

        Task Update(User user, CancellationToken cancellationToken);

        Task Delete(User user, CancellationToken cancellationToken);
    }
}
