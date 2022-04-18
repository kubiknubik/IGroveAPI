using Shared.Utils.Entities;
using System;
using System.Collections.Generic;

namespace IGrove.Domain.Players.Entities
{
    public class Player : IEntityIdentifier<long>
    {
        public long Id { get; set; }

        public string Username { get;set; }

        public int GoldCoin { get; set; }

        public int SilverCoin { get; set; }

        public string AvatarUrl { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public int AvailableCoin { get; set; }

        public List<GameRecord> GameRecords { get; set; } = new List<GameRecord>();
    }
}
