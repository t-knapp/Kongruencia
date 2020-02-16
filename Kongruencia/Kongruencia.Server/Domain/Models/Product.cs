using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Server {

	public class Product {

		public int id { get; private set; }
		public string productName { get; private set; }
		public IEnumerable<Branch> branches { get; private set; }


		public Product( string productName ) => this.productName = productName;


		public void AddBranch() {

		}
		public void RemoveBranch() {

		}
	}
}
