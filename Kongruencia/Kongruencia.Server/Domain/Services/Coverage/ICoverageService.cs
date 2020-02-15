using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domain.Services.Coverage
{
    public interface ICoverageService
    {
        Task<ServiceResult<bool>> AddAsync(Models.Coverage coverage);
    }
}
