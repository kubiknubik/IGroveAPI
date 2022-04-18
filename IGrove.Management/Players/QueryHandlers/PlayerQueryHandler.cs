using AutoMapper;
using IGrove.Domain.Players.Dtos;
using IGrove.Domain.Players.Queries;
using IGrove.Domain.Players.Repositories;
using Shared.Utils.Queries.Abstract;
using System.Threading;
using System.Threading.Tasks;

namespace IGrove.Management.Players.QueryHandlers
{
    public class PlayerQueryHandler : IQueryHandler<GetPlayerByIdQuery, PlayerDto>,
         IQueryHandler<GetPlayerByUsernameQuery, PlayerDto>
    {
        private readonly IPlayerReadRepository _playerReadRepository;
        private readonly IMapper _mapper;

        public PlayerQueryHandler(IPlayerReadRepository playerReadRepository, IMapper mapper)
        {
            _playerReadRepository = playerReadRepository;
            _mapper = mapper;
        }

        public async Task<PlayerDto> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _playerReadRepository.GetById(request.Id, cancellationToken);

            return _mapper.Map<PlayerDto>(result);
        }

        public async Task<PlayerDto> Handle(GetPlayerByUsernameQuery request, CancellationToken cancellationToken)
        {
            var result = await _playerReadRepository.GetByUsername(request.Username, cancellationToken);

            return _mapper.Map<PlayerDto>(result);
        }
    }
}
