using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Server {

	public class Build {

		public int id { get; private set; }
		public int buildNumber { get; private set; }

		public Coverage coverage { get; private set; }
	}
}
