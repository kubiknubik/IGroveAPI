using Shared.Utils.Commands;
using System.ComponentModel.DataAnnotations;

namespace IGrove.Domain.Players.Commands
{
    public class UpdatePlayerCommand : CommandBase
    {

    }

    public class GamePlayedCommand : CommandBase<object>
    {
        [Range(1, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int GameId { get; set; }

        public int PlayerId { get; set; }

        public int RoundId { get; set; }

        public int Point { get; set; }
    }
}