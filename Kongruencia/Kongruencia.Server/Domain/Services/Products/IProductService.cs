using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kongruencia.Server {

	public interface IProductService {
        Task<ServiceResult<Product>> AddProductAsync(string productName, CancellationToken cancellationToken);

        Task<ServiceResult<Branch>> AddBranchAsync(int productID, string branchName, CancellationToken cancellationToken);

        Task<ServiceResult<Build>> AddBuildAsync(int productID, int branchID, int buildNumber, Coverage coverage, CancellationToken cancellationToken);
    }

}
