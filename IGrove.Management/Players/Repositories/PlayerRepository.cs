using IGrove.Domain.Players.Entities;
using IGrove.Domain.Players.Repositories;
using Shared.Utils.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IGrove.Management.Players.Repositories
{
    public class PlayerRepository : BaseListRepository<Player, long>, IPlayerReadRepository, IPlayerWriteRepository
    {
        public PlayerRepository()
        {
            _data.Add(new Player
            {
                Id = 1,
                AvatarUrl = "avatar.png",
                AvailableCoin = 200,
                GoldCoin = 0,
                SilverCoin = 0,
                LastUpdateDate = DateTime.Now,
                Username = "joni777"
            }) ;
        }

        public Task<Player> GetByUsername(string username, CancellationToken cancellationToken)
        {
            return Task.FromResult(GetBy(e => e.Username == username, cancellationToken));
        }
    }
}
