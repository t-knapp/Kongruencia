using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Server {

    public class Coverage {

        public class Metric {
            public int Overall { get; set; }
            public int Covered { get; set; }
        }


        public DateTime Timestamp { get; private set; }

        public Metric Statements { get; private set; }
        public Metric Conditionals { get; private set; }
        public Metric Methods { get; private set; }
    }
}
