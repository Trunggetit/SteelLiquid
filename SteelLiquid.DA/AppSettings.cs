using SteelLiquid.DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteelLiquid.DA
{
    public class AppSettings : IAppSettings
    {
        public string NextgenBaseURL { get; set; }
        public string CoreApiBaseURL { get; set; }
        public string ScorecardsBaseURL { get; set; }
    }
}
