using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Server {

	public class ProductService : IProductService {

		private readonly IUnitOfWork _unitOfWork;



		public ProductService( IUnitOfWork unitOfWork ) => _unitOfWork = unitOfWork;


		public Task<Product> AddProductAsync( string productName ) {

			return null;
		}
	}
}
