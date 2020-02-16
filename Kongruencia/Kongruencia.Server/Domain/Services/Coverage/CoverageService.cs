using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Kongruencia.Server {

    public class CoverageService : ICoverageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverageService(IUnitOfWork unitOfWork) => (_unitOfWork) = (unitOfWork);

        public async Task<ServiceResult<Coverage>> AddAsync(Coverage coverage)
        {
            await _unitOfWork.coverageRepository.AddAsync(coverage);
            await _unitOfWork.CompleteAsync();
            return new ServiceResult<Coverage>(coverage);
        }
    }
}
