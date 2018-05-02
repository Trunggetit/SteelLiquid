using Dapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;

namespace SteelLiquid.DA
{
    public class GenericDA<T>
    {
        ILogger Logger;

        public GenericDA(ILogger logger)
        {
            Logger = logger;
        }

        public async Task<IEnumerable<T>> SelectAsync(IDbConnection connection, string query, object inputParameters)
        {
            Logger.LogDebug($"Executing query to get data for {nameof(T)}.");

            using (IDbConnection cn = connection)
            {
                cn.Open();

                try
                {

                    var results = await cn.QueryAsync<T>(query, param: inputParameters);
                    return results;
                }
                catch (System.Exception ex)
                {
                    Logger.LogError($"Unable to retrieve data for {nameof(T)}", ex);
                    throw;
                }
            }
        }
    }

}