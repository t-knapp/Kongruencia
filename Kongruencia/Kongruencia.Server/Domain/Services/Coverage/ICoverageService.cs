using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kongruencia.Server {

    public interface ICoverageService
    {
        Task<ServiceResult<IEnumerable<Coverage>>> ListAsync(Expression<Func<Coverage, bool>> filter);
        Task<ServiceResult<Coverage>> GetAsync(int id);
        Task<ServiceResult<Coverage>> AddAsync(Coverage coverage);
    }
}
