using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using SteelLiquid.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SteelLiquid.DA
{
    public class BaseDA
    {
        private readonly string _connectionString;
        public readonly bool _isUsingSqlConnection;
        public ILogger Logger { get; set; }

        public BaseDA(string connectionString, bool isUsingSqlConnection = true)
        {
            _connectionString = connectionString;
            _isUsingSqlConnection = isUsingSqlConnection;
        }

        public IDbConnection Connection
        {
            get
            {
                if (_isUsingSqlConnection)
                {
                    string sqlServerIP = DatabaseConnections.GetSqlServerIP().Trim();
                    Logger.LogInformation($"Query executed on Sql Server: {sqlServerIP}");

                    return new SqlConnection(string.Format(_connectionString, sqlServerIP, DatabaseConnections.SqlDefaultDBName));
                }

                return new MySqlConnection(string.Format(_connectionString, DatabaseConnections.GetMySqlServerIP(), DatabaseConnections.MySqlDefaultDBName));
            }
        }
    }
}