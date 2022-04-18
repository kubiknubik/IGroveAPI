using System;

namespace IGrove.Domain.Players.Dtos
{
    public class PlayerDto
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public int GoldCoin { get; set; }

        public int SilverCoin { get; set; }

        public string AvatarUrl { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public int AvailableCoin { get; set; }
    }
}
