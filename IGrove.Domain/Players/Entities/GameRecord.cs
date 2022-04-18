using System;

namespace IGrove.Domain.Players.Entities
{
    public class GameRecord
    {
        public int GameId { get; set; }

        public int RoundId { get; set; }

        public int Point { get; set; }

        public int GoidCoin { get; set; }

        public int SilverCoin { get; set; }

        public int DailyAvailableCoin { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
