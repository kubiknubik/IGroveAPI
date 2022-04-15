namespace IGrove.Domain.Games.Entities
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int LevelCount { get; set; }

        public string IconUrl { get; set; }

        public string CoverUrl { get; set; }

        public int Version { get; set; }
    }
}
