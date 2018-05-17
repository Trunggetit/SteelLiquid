using SteelLiquid.DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SteelLiquid.DA
{
    public class BaseRepository
    {
        private readonly IConnectionSettings _connectionStrings;

        public BaseRepository(IConnectionSettings connectionSettings)
        {
            _connectionStrings = connectionSettings;
        }

        public IDbConnection SqlConnection
        {
            get
            {
                return new SqlConnection(_connectionStrings.DefaultConnectionString);
            }
        }

    }
}
