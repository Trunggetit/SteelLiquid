using SteelLiquid.DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteelLiquid.DA.Connections
{
    public class ConnectionSettings : IConnectionSettings
    {
        public string DefaultConnectionString { get; set; }
        public string RedisConnectionString { get; set; }
    }
}
