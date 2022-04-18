using MediatR; 
using Shared.Utils.Repositories; 
using IGrove.Domain.Configs; 
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using IGrove.Management.Games.Repositories;
using IGrove.Domain.Games.Repositories;
using IGrove.Domain.Users.Repositories;
using IGrove.Management.Users.Repositories;
using IGrove.Management.Players.Repositories;
using IGrove.Management.Tickets.Repositories;
using IGrove.Domain.Tickets.Repositories;
using IGrove.Domain.Players.Repositories;

namespace IGrove.Management
{
    public static class Config
    {
        public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection("GameDomainConfig").Get<GameDomainConfig>();

            return services.AddSingleton<IGameDomainConfig>(config)
                           .AddSingleton<IDomainConfig>(config);
        }

        public static IServiceCollection AddManagement(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddMediatR(typeof(Config).Assembly)
                           .AddAutoMapper(typeof(Config).Assembly)
                           .AddTimeZoneServices(configuration);
        }

        public static IServiceCollection AddTimeZoneServices(this IServiceCollection services, IConfiguration configuration)
        {
            var gameRepo = new GameRepository();
            var userRepo = new UserRepository();
            var playerRepo = new PlayerRepository();
            var ticketRepo = new TicketRepository();

            return services.AddSingleton<IUserReadRepository>(userRepo)
                           .AddSingleton<IUserWriteRepository>(userRepo)
                           .AddSingleton<IGameReadRepository>(gameRepo)
                           .AddSingleton<IGameWriteRepository>(gameRepo)
                           .AddSingleton<ITicketWriteRepository>(ticketRepo)
                           .AddSingleton<ITicketReadRepository>(ticketRepo)
                           .AddSingleton<IPlayerWriteRepository>(playerRepo)
                           .AddSingleton<IPlayerReadRepository>(playerRepo);
        }
    }
}