using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Infrastructure.EntityFramework.Context.Factory
{
    internal class SepTaskDbContextFactory : IDesignTimeDbContextFactory<SepTaskDbContext>
    {
        public SepTaskDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SepTaskDbContext>();
            optionsBuilder.UseSqlServer($"data Source =192.168.57.51;Initial Catalog={DataBaseConfig.Sep_GameStore_DataBase};User ID=sa;Password=Pdn@Admin;MultipleActiveResultSets=true;TrustServerCertificate=True");
            var dbContext = new SepTaskDbContext(optionsBuilder.Options);
            return dbContext;
        }
    }
}
