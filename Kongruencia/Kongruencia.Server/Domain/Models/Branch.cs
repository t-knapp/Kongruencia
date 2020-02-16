using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Server {

	public class Branch {

		public int id { get; private set; }
		public string branchName { get; private set; }

		public IEnumerable<Build> builds { get; private set; }
	}
}
