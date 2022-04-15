using MediatR; 
using Shared.Utils.Repositories; 
using IGrove.Domain.Configs; 
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using IGrove.Management.Games.Repositories;
using IGrove.Domain.Games.Repositories;

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

            return services.AddSingleton<IUserReadRepository, UserReadRepository>()
                           .AddSingleton<IUserWriteRepository, UserWriteRepository>()
                           .AddSingleton<IGameReadRepository>(gameRepo)
                           .AddSingleton<IGameWriteRepository>(gameRepo);
        }
    }
}