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
        Task Delete(Player player, CancellationToken cancellationToken);
    }

    public interface IPlayerReadRepository
    {
        Task<Player> GetById(long id, CancellationToken cancellationToken);
        Task<Player> GetByPhone(string phone, CancellationToken cancellationToken);
        Task<Player> GetByUsername(string email, CancellationToken cancellationToken);
        Task<IEnumerable<Player>> GetAll(CancellationToken cancellationToken);
    }
}
