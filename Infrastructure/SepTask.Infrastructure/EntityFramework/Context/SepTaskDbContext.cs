using Microsoft.EntityFrameworkCore;
using SepTask.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Infrastructure.EntityFramework.Context
{
    public class SepTaskDbContext(DbContextOptions<SepTaskDbContext> options) : DbContext(options)
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var entityTypeConfigurations = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
                .ToList();

            foreach (var type in entityTypeConfigurations)
            {
                dynamic configurationInstance = Activator.CreateInstance(type)!;
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}
