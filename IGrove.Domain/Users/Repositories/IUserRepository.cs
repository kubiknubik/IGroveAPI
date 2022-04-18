using IGrove.Domain.Users.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace IGrove.Domain.Users.Repositories
{
    public interface IUserReadRepository
    {
        Task<User> GetById(long id, CancellationToken cancellationToken);

        Task<User> GetByName(string name, CancellationToken cancellationToken);

        Task<User> GetByPhone(string phone, CancellationToken cancellationToken);
    }

    public interface IUserWriteRepository
    {
        Task Add(User user, CancellationToken cancellationToken);

        Task Update(User user, CancellationToken cancellationToken);

        Task Remove(User user, CancellationToken cancellationToken);
    }
}
