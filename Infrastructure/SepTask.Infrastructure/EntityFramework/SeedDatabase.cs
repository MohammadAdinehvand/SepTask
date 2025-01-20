using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using SepTask.Domain.Models;
using SepTask.Infrastructure.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Infrastructure.EntityFramework
{
    internal static class SeedDatabase
    {
        public static void SeedData(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SepTaskDbContext>();
                dbContext.Database.Migrate();

                if (!dbContext.Genres.Any())
                {
                    dbContext.Genres.Add(new Genre(Guid.NewGuid(), "First-person shooter"));

                    dbContext.SaveChanges();
                }

            }





        }
    }
}
