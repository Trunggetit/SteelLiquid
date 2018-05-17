using System;
using System.Collections.Generic;
using System.Text;

namespace SteelLiquid.DA.Interfaces
{
    public interface IAppSettings
    {
        string NextgenBaseURL { get; set; }
        string CoreApiBaseURL { get; set; }
        string ScorecardsBaseURL { get; set; }
    }
}
