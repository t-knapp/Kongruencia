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

        public async Task<ServiceResult<IEnumerable<Coverage>>> ListAsync(string productName, string branchName, int buildNumber = -1)
        {
            IEnumerable<Coverage> list;

            if (productName is null && branchName is null && buildNumber is -1)
                list = await _unitOfWork.coverageRepository.GetAsync();
            else 
                list = await _unitOfWork.coverageRepository.GetAsync(
                    c => c.ProductName == productName && c.BranchName == branchName && c.BuildNumber == buildNumber
                );

            return new ServiceResult<IEnumerable<Coverage>>(list);
        }

        public Task<ServiceResult<Coverage>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<Coverage>> AddAsync(Coverage coverage)
        {
            await _unitOfWork.coverageRepository.AddAsync(coverage);
            await _unitOfWork.CompleteAsync();
            return new ServiceResult<Coverage>(coverage);
        }


    }
}
