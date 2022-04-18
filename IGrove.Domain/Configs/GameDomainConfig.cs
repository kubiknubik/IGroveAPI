namespace IGrove.Domain.Configs
{
    public class GameDomainConfig : IGameDomainConfig
    {
        public string ConnectionString { get; set; }

        public int DailyAvailablePoints { get; set; }
    }
}
