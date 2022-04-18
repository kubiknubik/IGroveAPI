using Shared.Utils.Commands;

namespace IGrove.Domain.Players.Commands
{
    public class UpdatePlayerCommand : CommandBase
    {

    }

    public class GamePlayedCommand : CommandBase<object>
    {
        public int GameId { get; set; }

        public int PlayerId { get; set; }

        public int RoundId { get; set; }

        public int Point { get; set; }
    }
}