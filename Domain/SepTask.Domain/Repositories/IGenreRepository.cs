using SepTask.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Domain.Repositories
{
    public interface IGenreRepository
    {
        Task<Genre?> GetByIdAsync(Guid id);
        Task<IEnumerable<Genre>> GetAllAsync();
    }
}
