using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domain.Models
{
    public class Coverage
    {
        public string ProductName { set; get; }
        public string BranchName { set; get; }
        public int BuildNumber { set; get; }
        public string FilePath { set; get; }

        public int Statements { set; get; }
        public int CoveredStatements { set; get; }
    }
}
