using IGrove.Domain.Players.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IGrove.Domain.Players.Repositories
{
    public interface IPlayerWriteRepository
    {
        Task Add(Player player, CancellationToken cancellationToken);
        Task Update(Player player, CancellationToken cancellationToken);
        Task Remove(Player player, CancellationToken cancellationToken);
    }

    public interface IPlayerReadRepository
    {
        Task<Player> GetById(long id, CancellationToken cancellationToken);
        Task<Player> GetByUsername(string username, CancellationToken cancellationToken);
        Task<IEnumerable<Player>> GetAll(CancellationToken cancellationToken);
    }
}
