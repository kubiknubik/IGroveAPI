using IGrove.Domain.Games.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IGrove.Domain.Games.Repositories
{
    public interface IGameWriteRepository
    {
       Task Add(Game game, CancellationToken cancellationToken);

       Task Update(Game game, CancellationToken cancellationToken);

       Task Remove(Game game, CancellationToken cancellationToken);
    }

    public interface IGameReadRepository
    {
        Task<Game> GetById(int id, CancellationToken cancellationToken);

        Task<IEnumerable<Game>> GetAll(CancellationToken cancellationToken);
    }
}
