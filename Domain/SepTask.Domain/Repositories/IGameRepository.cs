using SepTask.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Domain.Repositories
{
    public interface IGameRepository
    {
        Task AddAsync(Game game);
        Task UpdateAsync(Game game);
        Task RemoveAsync(Game game);
        Task<Game?> GetByIdAsync(Guid id);
        Task<Game?> GetByNameAsync(string name);
        Task<bool> CheckDuplicatedNameAsync(Game game);
    }
}
