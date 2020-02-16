using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Server {

    public interface ICoverageService
    {
        Task<ServiceResult<IEnumerable<Coverage>>> ListAsync(string productName, string branchName, int buildNumber); // TODO: Query Fn?
        Task<ServiceResult<Coverage>> GetAsync(int id);
        Task<ServiceResult<Coverage>> AddAsync(Coverage coverage);
    }
}
