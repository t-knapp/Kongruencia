using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domain.Parsers
{
    public interface ICoverageParser
    {
        Task<int> ParseTotalLines();
    }
}
