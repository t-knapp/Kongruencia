using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Server {

    public class Coverage {

        public class Metric {
            public int Overall { get; }
            public int Covered { get; }


            public Metric( int overall, int covered )
                => (Overall, Covered) = (overall, covered);
        }


        public DateTime Timestamp { get; set; }

        public Metric Statements { get; set; }
        public Metric Conditionals { get; set; }
        public Metric Methods { get; set; }
        public Metric Elements { get; set; }
    }
}
