using IGrove.Domain.Games.Commands;
using IGrove.Domain.Games.Entities;
using IGrove.Domain.Games.Repositories;
using MediatR;
using Shared.Utils.Commands.Abstract;
using Shared.Utils.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IGrove.Management.Games.CommandHandlers
{
    public class GameCommandHandler : ICommandHandler<AddGameCommand, Unit>,
        ICommandHandler<UpdateGameCommand, Unit>,
        ICommandHandler<DeleteGameCommand, Unit>
    {
        private readonly IGameReadRepository _gameReadRepository;
        private readonly IGameWriteRepository _gameWriteRepository;

        public GameCommandHandler(IGameReadRepository gameReadRepository, IGameWriteRepository gameWriteRepository)
        {
            _gameReadRepository = gameReadRepository ?? throw new ArgumentNullException(nameof(gameReadRepository));
            _gameWriteRepository = gameWriteRepository ?? throw new ArgumentNullException(nameof(gameWriteRepository));
        }

        public async Task<Unit> Handle(AddGameCommand request, CancellationToken cancellationToken)
        {
            var checkGame = await _gameReadRepository.GetById(request.Id, cancellationToken);

            if (checkGame != null)
            {
                throw new BusinessRuleValidationException(InternalExceptionCode.GameAlreadyExists);
            }

            var game = new Game
            {
                Id = request.Id,
                CoverUrl = request.CoverUrl,
                Name = request.Name,
                Description = request.Description,
                IconUrl = request.IconUrl,
                RoundCount = request.RoundCount,
                Version = 1
            };

            await _gameWriteRepository.Add(game, cancellationToken);

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var checkGame = await _gameReadRepository.GetById(request.Id, cancellationToken);

            if (checkGame == null)
            {
                throw new BusinessRuleValidationException(InternalExceptionCode.GameDoesntExist);
            }

            checkGame.Description = request.Description;
            checkGame.CoverUrl = request.CoverUrl;
            checkGame.IconUrl = request.IconUrl;
            checkGame.Name = request.Name;
            checkGame.RoundCount = request.RoundCount;
            checkGame.Version++;

            await _gameWriteRepository.Update(checkGame, cancellationToken);

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            var checkGame = await _gameReadRepository.GetById(request.Id, cancellationToken);

            if (checkGame == null)
            {
                throw new BusinessRuleValidationException(InternalExceptionCode.GameDoesntExist);
            }

            await _gameWriteRepository.Remove(checkGame, cancellationToken);

            return Unit.Value;
        }
    }
}
