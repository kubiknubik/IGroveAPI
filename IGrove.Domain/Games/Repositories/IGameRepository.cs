using IGrove.Domain.Games.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IGrove.Domain.Games.Repositories
{
    public interface IGameWriteRepository
    {

    }

    public interface IGameReadRepository
    {
        Task<Game> GetGameById(int id, CancellationToken cancellationToken);

        Task<IEnumerable<Game>> GetAll(CancellationToken cancellationToken);
    }
}
