using IGrove.Domain.Configs;
using IGrove.Domain.Games.Repositories;
using IGrove.Domain.Players.Commands;
using IGrove.Domain.Players.Entities;
using IGrove.Domain.Players.Repositories;
using MediatR;
using Shared.Utils.Commands.Abstract;
using Shared.Utils.Exceptions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IGrove.Management.Players.CommandHandlers
{
    public class PlayerCommandHandler : ICommandHandler<GamePlayedCommand, object>
    {
        private readonly IPlayerReadRepository _playerReadRepo;
        private readonly IPlayerWriteRepository _playerWriteRepository;
        private readonly IGameReadRepository _gameReadRepository;
        private readonly IGameDomainConfig _gameDomainConfig;

        public PlayerCommandHandler(IPlayerReadRepository playerReadRepo, 
            IPlayerWriteRepository playerWriteRepository, 
            IGameReadRepository gameReadRepository, 
            IGameDomainConfig gameDomainConfig)
        {
            _playerReadRepo = playerReadRepo;
            _playerWriteRepository = playerWriteRepository;
            _gameReadRepository = gameReadRepository;
            _gameDomainConfig = gameDomainConfig;
        }


        public async Task<object> Handle(GamePlayedCommand request, CancellationToken cancellationToken)
        {
            var gameTask = _gameReadRepository.GetById(request.GameId, cancellationToken);
            var playerTask = _playerReadRepo.GetById(request.PlayerId, cancellationToken); 

            await Task.WhenAll(gameTask, playerTask);

            var game = gameTask.Result;
            var player = playerTask.Result;

            if (game == null)
            {
                throw new BusinessRuleValidationException(InternalExceptionCode.IncorrectGame);
            }

            if (request.RoundId < 1 || game.LevelCount < request.RoundId)
            {
                throw new BusinessRuleValidationException(InternalExceptionCode.IncorrectRound);
            }

            var gameRecord = player.GameRecords
                .Where(e => e.GameId == request.GameId && e.RoundId == request.RoundId)
                .OrderByDescending(e=>e.CreateDate)
                .FirstOrDefault();

            var availableCoin = 0;
             
            if (gameRecord == null || gameRecord.CreateDate.DayOfYear != DateTime.Now.DayOfYear)
            {
                availableCoin = _gameDomainConfig.DailyAvailablePoints;
            }
            else
            {
                availableCoin = gameRecord.DailyAvailableCoin;
            } 

            var goldCoin = request.Point > availableCoin ? availableCoin : request.Point;
            var silverCoin = request.Point - goldCoin;
            availableCoin -= goldCoin;

            player.GoldCoin += goldCoin;
            player.SilverCoin += silverCoin;

            player.LastUpdateDate = DateTime.Now;

            var currentRecord = new GameRecord
            {
                CreateDate = DateTime.Now,
                GameId = request.GameId,
                RoundId = request.RoundId,
                Point = request.Point,
                SilverCoin = silverCoin,
                GoidCoin = goldCoin,
                DailyAvailableCoin = availableCoin
            };

            player.GameRecords.Add(currentRecord);

            await _playerWriteRepository.Update(player, cancellationToken);

            return new {
                goldCoin , 
                silverCoin,
                availableCoin,
                totalGoldCoin = player.GoldCoin,
                totalSilverCoin = player.SilverCoin
            };
        }
    }
}
