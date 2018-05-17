using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SteelLiquid.DA;
using SteelLiquid.DA.Connections;
using SteelLiquid.DA.Interfaces;
using SteelLiquid.Entity.MTG;

namespace SteelLiquid.API.Dependencies
{
    public class Dependencies
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IConnectionSettings, ConnectionSettings>();
            services.AddSingleton<IAppSettings, AppSettings>();
            services.AddSingleton<ICardInventory, DA.CardInventoryDA>();
        }
    }
}
