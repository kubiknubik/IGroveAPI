using System;

namespace IGrove.Domain.Players.Entities
{
    public class Player
    {
        public long Id { get; set; }

        public int GoldCoin { get; set; }

        public int SilverCoin { get; set; }

        public string AvatarUrl { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public int DailyGeneratedCoin { get; set; }
    }
}
