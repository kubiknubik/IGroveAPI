using IGrove.Domain.Games.Entities;
using IGrove.Domain.Games.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IGrove.Management.Games.Repositories
{
    public class GameRepository : IGameReadRepository, IGameWriteRepository
    {
        private readonly List<Game> _games;

        public GameRepository()
        {
            _games = new List<Game> { 
                new Game{
                            Id = 1,
                            Description ="Mario is platformer game",
                            Name = "Mario",
                            LevelCount = 47,
                            CoverUrl ="1_cover.png",
                            IconUrl ="1_icon.png",
                            Version =1
                        },
                new Game{
                            Id = 2,
                            Description ="Tetris is platformer game",
                            Name = "Tetris",
                            LevelCount = 23,
                            CoverUrl ="2_cover.png",
                            IconUrl ="2_icon.png",
                            Version =2
                        }, 
                new Game{
                            Id = 3,
                            Description ="Subway Surfer is infinity runner",
                            Name = "Subway Surfer",
                            LevelCount = 1,
                            CoverUrl ="3_cover.png",
                            IconUrl ="3_icon.png",
                            Version =4
                        }
            };
        }

        public Task<IEnumerable<Game>> GetAll(CancellationToken cancellationToken)
        {
            return Task.FromResult(_games.AsEnumerable());
        }

        public Task<Game> GetGameById(int id, CancellationToken cancellationToken)
        {
            return Task.FromResult(_games.FirstOrDefault(e => e.Id == id));
        }
    }
}
