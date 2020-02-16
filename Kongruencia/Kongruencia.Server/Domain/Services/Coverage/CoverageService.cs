using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Kongruencia.Server {

    public class CoverageService : ICoverageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverageService(IUnitOfWork unitOfWork) 
            => _unitOfWork = unitOfWork;

        public Task<ServiceResult<bool>> AddAsync(Coverage coverage)
        {
            // TODO: Store to DB

            return Task.FromResult(new ServiceResult<bool>(true));
        }
    }
}
