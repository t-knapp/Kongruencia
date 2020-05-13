using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;
using MongoDB.Entities.Core;

namespace Kongruencia.Server {

	public class Product : Entity {

		[BsonElement]
		private IList<Branch> _branches = new List<Branch>();

		public string ProductName { get; private set; }

		[BsonIgnore]
		[UseFiltering]
		public IEnumerable<Branch> Branches => _branches;


		public Product( string productName ) 
			=> ProductName = productName;


		[GraphQLIgnore]
		public Branch AddBranch( string branchName )
			=> _branches.AddAndReturn( new Branch( branchName ));

		[GraphQLIgnore]
		public void RemoveBranch( string branchName ) {
			var branch = _branches.SingleOrDefault( b => b.BranchName == branchName );
			if( branch != null )
				_branches.Remove( branch );
        }
	}
}
