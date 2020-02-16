using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kongruencia.Server {

	public class ProductService : IProductService {

		private readonly IUnitOfWork _unitOfWork;


		public ProductService( IUnitOfWork unitOfWork ) => _unitOfWork = unitOfWork;


		public Task<Product> AddProductAsync( string productName, CancellationToken cancellationToken = default ) {
			_unitOfWork.productRepository.AddAsync( new Product( productName ), cancellationToken );
			return null;
		}
		public Task<Branch> AddBranchAsync( int productID, string branchName, CancellationToken cancellationToken = default ) {

			return null;
		}
		public Task<Build> AddBuildAsync( int productID, int branchID, int buildNumber, Coverage coverage, CancellationToken cancellationToken = default ) {

			return null;
		}
	}
}
