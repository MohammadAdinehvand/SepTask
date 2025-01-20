
using SepTask.Domain.Repositories;
using SepTask.Infrastructure.EntityFramework.Repositories;
using Microsoft.Extensions.DependencyInjection;
using SepTask.Infrastructure.EntityFramework;
using Microsoft.Extensions.Configuration;
using SepTask.Infrastructure.Dapper;
namespace SepTask.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServer(configuration);
            services.AddDapperSqlServer(configuration);
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            return services;
        }
    }
}
