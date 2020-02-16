using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Server {

	public class Metrics {
        public int statements { get; private set; }
        public int coveredstatements { get; private set; }
        public int conditionals { get; private set; }
        public int coveredconditionals { get; private set; }
        public int methods { get; private set; }
        public int coveredmethods { get; private set; }
    }
}
