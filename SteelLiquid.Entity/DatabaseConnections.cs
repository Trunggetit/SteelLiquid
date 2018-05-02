using System;
using System.Collections.Generic;

namespace SteelLiquid.Entity
{
    public static class DatabaseConnections
    {
        public static Dictionary<string, string> ConnectionStrings { get; private set; } =
            new Dictionary<string, string>();

        public static void AddConectionString(string name, string connectionString) => ConnectionStrings.Add(name, connectionString);

        public static List<string> SqlDBServers { get; set; } = new List<string>();
        public static List<string> MySqlDBServers { get; set; } = new List<string>();

        public static string SqlDefaultDBName { get; set; }
        public static string MySqlDefaultDBName { get; set; }

        public static string GetSqlServerIP()
        {
            int pickRandomizeServerIPIndex = new Random().Next(SqlDBServers.Count);
            return SqlDBServers[pickRandomizeServerIPIndex];
        }

        public static string GetMySqlServerIP()
        {
            int pickRandomizeServerIPIndex = new Random().Next(MySqlDBServers.Count);
            return MySqlDBServers[pickRandomizeServerIPIndex];
        }
    }
}