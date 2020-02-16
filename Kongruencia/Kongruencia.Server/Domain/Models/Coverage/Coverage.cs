using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Server 
{
    public class Coverage
    {

        public int id { get; private set; } 

        public DateTime timestamp { get; private set; }
        public Metrics metrics { get; private set; }

        public Product product { get; private set; }
        public Branch branch { get; private set; }
        public Build build { get; private set; }

        public IEnumerable<Package> packages { get; private set; }


        //Old
        public string ProductName { set; get; }
        public string BranchName { set; get; }
        public int BuildNumber { set; get; }
        public string FilePath { set; get; }

        public int Statements { set; get; }
        public int CoveredStatements { set; get; }
    }
}
