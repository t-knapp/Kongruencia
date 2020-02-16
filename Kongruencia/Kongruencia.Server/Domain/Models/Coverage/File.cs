using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Server {

	public class File {

		public int id { get; private set; }

		public string name { get; private set; }
		public string path { get; private set; }

		public Metrics metrics { get; private set; }
	}
}
