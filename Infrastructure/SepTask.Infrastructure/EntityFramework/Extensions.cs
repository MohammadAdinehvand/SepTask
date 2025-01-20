using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SepTask.Infrastructure.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Infrastructure.EntityFramework
{
    public static class Extensions
    {
        public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(DataBaseConfig.Sep_GameStore_DataBase);
            services.AddDbContext<SepTaskDbContext>(ctx => ctx.UseSqlServer(connectionString));
            services.SeedData();
            return services;
        }
    }
}
