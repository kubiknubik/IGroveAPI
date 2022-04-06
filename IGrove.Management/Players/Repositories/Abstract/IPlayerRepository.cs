using IGrove.Domain.Players.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace IGrove.Management.Players.Repositories.Abstract
{
    public interface IPlayerWriteRepository
    {
        Task Add(Player player, CancellationToken cancellationToken);

        Task Update(Player player, CancellationToken cancellationToken);
    }

    public interface IPlayerReadRepository
    {
        Task GetById(int id, CancellationToken cancellationToken);

        Task GetByUserName(string username, CancellationToken cancellationToken);

        Task GetByPhoneNumber(string phone, CancellationToken cancellationToken);
    }
}
