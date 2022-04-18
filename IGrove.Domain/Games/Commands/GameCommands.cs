using Shared.Utils.Commands;

namespace IGrove.Domain.Games.Commands
{
    public class AddGameCommand : CommandBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string IconUrl { get; set; }

        public string CoverUrl { get; set; }

        public int RoundCount { get; set; }
    }

    public class UpdateGameCommand : CommandBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string IconUrl { get; set; }

        public string CoverUrl { get; set; }

        public int RoundCount { get; set; }
    }

    public class DeleteGameCommand : CommandBase
    {
        public int Id { get; set; }        
    }
}
