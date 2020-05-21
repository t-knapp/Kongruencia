using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Server {

	public class Build {

		public int BuildNumber { get; private set; }
		public Coverage Coverage { get; private set; }


		public Build( int buildNumber, Coverage coverage ) {
			BuildNumber = buildNumber;
			Coverage = coverage ?? throw new ArgumentNullException( nameof( coverage ) );
        }
	} 
}
