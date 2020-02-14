using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domain.Parsers
{
    public class CloverXmlFileParser : ICoverageParser
    {
        public Task<int> ParseTotalLines()
        {
            return Task.FromResult(1);
        }
    }
}
