using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml;

namespace Kongruencia.Server {

    public class CoverageService : ICoverageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverageService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ServiceResult<IEnumerable<Coverage>>> ListAsync(string productName, string branchName, int buildNumber = -1)
        {
            var predicate = PredicateBuilder.New<Coverage>(true);
            if (!(productName is null))
                predicate = predicate.And(c => c.ProductName.Equals(productName));
            if (!(branchName is null))
                predicate = predicate.And(c => c.BranchName.Equals(branchName));
            if (!(buildNumber is -1))
                predicate = predicate.And(c => c.BuildNumber == buildNumber);
            var list = await _unitOfWork.coverageRepository.GetAsync(predicate);
            return new ServiceResult<IEnumerable<Coverage>>(list);
        }

        public async Task<ServiceResult<Coverage>> GetAsync(int id)
        {
            var coverage = await _unitOfWork.coverageRepository.GetAsync(id);
            return new ServiceResult<Coverage>(coverage);
        }

        public async Task<ServiceResult<Coverage>> AddAsync(Coverage coverage)
        {
            var list = await ListAsync(coverage.ProductName, coverage.BranchName, coverage.BuildNumber);
            if (list.isSuccess && list.result.Count() > 0)
                return new ServiceResult<Coverage>("Coverage already exists");

            await _unitOfWork.coverageRepository.AddAsync(coverage);
            await _unitOfWork.CompleteAsync();
            return new ServiceResult<Coverage>(coverage);
        }

    }
}
