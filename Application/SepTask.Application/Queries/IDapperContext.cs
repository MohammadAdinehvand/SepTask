using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Application.Queries
{
    public interface IDapperContext
    {
        Task<IEnumerable<T>> GetAllAsync<T>(string storedProcedureName, Dictionary<string, object> parameters=null);
        Task<T> GetAsync<T>(string storedProcedureName, Dictionary<string, object> parameters = null);
    }
}
