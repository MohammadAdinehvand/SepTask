using Dapper;
using Microsoft.Data.SqlClient;
using SepTask.Application.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Infrastructure.Dapper
{
    internal class DapperContext : IDapperContext
    {
        private readonly string _connectionString;
        public DapperContext(string connectionString)
        {
            _connectionString=connectionString; 
        }
        public async Task<IEnumerable<T>> GetAllAsync<T>(string storedProcedureName, Dictionary<string, object> parameters = null)
        {
            await using var connection = new SqlConnection(_connectionString);
            var dynamicParameters = new DynamicParameters();

            if (parameters is not null) 
            {
                dynamicParameters.AddDynamicParams(parameters);
            }

            return await connection.QueryAsync<T>(storedProcedureName, dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> GetAsync<T>(string storedProcedureName, Dictionary<string, object> parameters = null)
        {
            await using var connection = new SqlConnection(_connectionString);
            var dynamicParameters = new DynamicParameters();

            if (parameters is not null)
            {
                dynamicParameters.AddDynamicParams(parameters);
            }

            return await connection.QueryFirstAsync<T>(storedProcedureName, dynamicParameters, commandType: CommandType.StoredProcedure);
        }
    }
}
