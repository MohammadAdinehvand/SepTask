
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SepTask.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Infrastructure.EntityFramework.Configurations
{
    public class GamgeConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable(nameof(Game));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .HasDefaultValueSql("NEWSEQUENTIALID()") // Or "NEWID()"
                   .HasColumnOrder(1);
            builder.Property(x => x.Name).HasColumnOrder(3).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.Price).HasColumnOrder(4).HasColumnType("DECIMAL(10,2)").IsRequired();

            var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
            dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime));

            builder.Property(x => x.ReleaseDate)
                                         .HasColumnType("date")
                                         .HasConversion(dateOnlyConverter)
                                         .HasColumnOrder(5)
                                         .IsRequired();


            builder.HasOne(x => x.Genre)
                   .WithMany()
                   .HasForeignKey("GenreId");


            builder.Property("GenreId").HasColumnOrder(2);
        }
    }
}
