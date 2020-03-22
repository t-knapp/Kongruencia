using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruenzia.Client.Blazor.Graphs
{
    public class ColorHelper
    {
        private static readonly Dictionary<ECoverageType, string> _colorMap = new Dictionary<ECoverageType, string>() {
            { ECoverageType.TOTAL, "#034990" },
            { ECoverageType.COVERED, "#76b82a" },
            { ECoverageType.UNCOVERED, "#b82a2a" }
        };

        public static string GetCoverageTypeColor(ECoverageType type)
        {
            return _colorMap[type];
        }
    }
}
