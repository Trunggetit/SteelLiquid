using System;
using System.Collections.Generic;
using System.Text;

namespace SteelLiquid.DA.Interfaces
{
    public interface IConnectionSettings
    {
        string DefaultConnectionString { get; set; }
        string RedisConnectionString { get; set; }
    }
}
