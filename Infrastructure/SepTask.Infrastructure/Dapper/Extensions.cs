using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SepTask.Application.Queries;
using SepTask.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Infrastructure.Dapper
{
    internal static class Extensions
    {
        public static IServiceCollection AddDapperSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(DataBaseConfig.Sep_GameStore_DataBase);
            services.AddSingleton<IDapperContext>(_ => new DapperContext(connectionString));
            return services;
        }
    }
}
