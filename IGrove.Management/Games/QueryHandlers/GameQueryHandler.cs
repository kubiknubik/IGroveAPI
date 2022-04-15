using IGrove.Domain.Games.Entities;
using IGrove.Domain.Games.Queries;
using IGrove.Domain.Games.Repositories;
using Shared.Utils.Queries.Abstract;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IGrove.Management.Games.QueryHandlers
{
    public class GameQueryHandler : IQueryHandler<GetGameByIdQuery, Game>,
         IQueryHandler<GetAllGameQuery, IEnumerable<Game>>
    {
        private readonly IGameReadRepository _gameReadRepository;

        public GameQueryHandler(IGameReadRepository gameReadRepository)
        {
            _gameReadRepository = gameReadRepository;
        }

        public Task<Game> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            return _gameReadRepository.GetGameById(request.Id, cancellationToken);
        }

        public Task<IEnumerable<Game>> Handle(GetAllGameQuery request, CancellationToken cancellationToken)
        {
            return _gameReadRepository.GetAll(cancellationToken);
        }
    }
}
