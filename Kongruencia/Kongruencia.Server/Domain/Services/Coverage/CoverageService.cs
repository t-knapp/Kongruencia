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
            IEnumerable<Coverage> list;
            /*
            Expression<Func<Coverage, bool>> expression = coverage => true;
            BinaryExpression ex;
            if (!(productName is null))
            {
                Expression<Func<Coverage, bool>> productNameExpression = coverage => coverage.ProductName.Equals(productName);
                ex = Expression.And(expression, productNameExpression);
            }

            if (!(branchName is null))
            {
                Expression<Func<Coverage, bool>> branchNameExpression = coverage => coverage.BranchName.Equals(branchName);
                ex = Expression.And(ex, branchNameExpression);
            }
            list = await _unitOfWork.coverageRepository.GetAsync(expression);
            */


            /*
            list = await _unitOfWork.coverageRepository.GetAsync(
                c =>
                {
                    bool matches = true;
                    if (!(productName is null))
                        matches = false

                    return matches;
                }
            );
            */

            if (productName is null && branchName is null && buildNumber is -1)
                list = await _unitOfWork.coverageRepository.GetAsync();
            else 
                list = await _unitOfWork.coverageRepository.GetAsync(
                    c => c.ProductName == productName && c.BranchName == branchName && c.BuildNumber == buildNumber
                );

            return new ServiceResult<IEnumerable<Coverage>>(list);
        }

        public async Task<ServiceResult<Coverage>> GetAsync(int id)
        {
            var coverage = await _unitOfWork.coverageRepository.GetAsync(id);
            return new ServiceResult<Coverage>(coverage);
        }

        public async Task<ServiceResult<Coverage>> AddAsync(Coverage coverage)
        {
            await _unitOfWork.coverageRepository.AddAsync(coverage);
            await _unitOfWork.CompleteAsync();
            return new ServiceResult<Coverage>(coverage);
        }

    }
}
