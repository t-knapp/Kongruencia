using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Server {

    public interface ICoverageService
    {
        Task<ServiceResult<Coverage>> AddAsync(Coverage coverage);
        // TODO: GetAsync
        // TODO: ListAsync
    }
}
