using Shared.Utils.Repositories;

namespace IGrove.Domain.Configs
{
    public interface IGameDomainConfig : IDomainConfig
    {
        public int DailyAvailablePoints { get; set; }
    }
}
