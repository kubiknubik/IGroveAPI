using Shared.Utils.Entities;

namespace IGrove.Domain.Games.Entities
{
    public class Game : IEntityIdentifier<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int RoundCount { get; set; }

        public string IconUrl { get; set; }

        public string CoverUrl { get; set; }

        public int Version { get; set; }
    }
}
