using Microsoft.EntityFrameworkCore;
using SepTask.Domain.Models;
using SepTask.Domain.Repositories;
using SepTask.Infrastructure.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Infrastructure.EntityFramework.Repositories
{
    internal class GenreRepository : IGenreRepository
    {
        private DbSet<Genre> _genres => _sepTaskDbContext.Genres;
        private readonly SepTaskDbContext _sepTaskDbContext;

        public GenreRepository(SepTaskDbContext sepTaskDbContext)
        {
            _sepTaskDbContext = sepTaskDbContext;
        }
        public async Task<Genre?> GetByIdAsync(Guid id)
        {
            return await _sepTaskDbContext.Genres.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _sepTaskDbContext.Genres.AsNoTracking().ToListAsync();
        }
    }
}
