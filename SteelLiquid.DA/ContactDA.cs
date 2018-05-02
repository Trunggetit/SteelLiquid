using Microsoft.Extensions.Logging;
using SteelLiquid.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteelLiquid.DA
{
    public class ContactDA : BaseDA
    {
        public ContactDA(ILogger<ContactDA> logger) : base(DatabaseConnections.ConnectionStrings["SqlDefaultConnection"])
        {
            Logger = logger;
        }
    }
}
