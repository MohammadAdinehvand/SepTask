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
    internal class GameRepository : IGameRepository
    {

        private DbSet<Game> _games => _sepTaskDbContext.Games;
        private readonly SepTaskDbContext _sepTaskDbContext;

        public GameRepository(SepTaskDbContext sepTaskDbContext)
        {
            _sepTaskDbContext = sepTaskDbContext;
        }
        public async Task AddAsync(Game game)
        {
            _games.Add(game);
            await _sepTaskDbContext.SaveChangesAsync();
        }

        public async Task<Game?> GetByIdAsync(Guid id)
        {
            return await _sepTaskDbContext.Games.Include(x=>x.Genre).FirstOrDefaultAsync(x => x.Id==id);
        }

        public async Task<Game?> GetByNameAsync(string name)
        {
            return await _sepTaskDbContext.Games.Include(x => x.Genre).FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task UpdateAsync(Game game)
        {
            _games.Update(game);
            await _sepTaskDbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckDuplicatedNameAsync(Game game)
        {
            return await _sepTaskDbContext.Games.Include(x => x.Genre).AnyAsync(x => x.Name == game.Name && x.Id != game.Id);
        }

        public async Task RemoveAsync(Game game)
        {
            _games.Remove(game);
            await _sepTaskDbContext.SaveChangesAsync();
        }
    }
}
