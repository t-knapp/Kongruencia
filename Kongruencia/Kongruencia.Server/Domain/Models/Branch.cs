using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using MongoDB.Bson.Serialization.Attributes;

namespace Kongruencia.Server {

	public class Branch {

		[BsonElement]
		private IList<Build> _builds = new List<Build>();

		public string BranchName { get; private set; }

		[BsonIgnore]
		[UseFiltering]
		public IEnumerable<Build> Builds => _builds;


		public Branch( string name )
			=> BranchName = name;


		[GraphQLIgnore]
		public Build AddBuild( int buildNumber, Coverage coverage ) 
			=> _builds.AddAndReturn( new Build( buildNumber, coverage ) );
	}
}
