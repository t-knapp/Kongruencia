using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kongruencia.Data.Domain.Models;

namespace Kongruencia.Data.Domain.Services
{
    public class CoverageHttpProvider : ICoverageProvider
    {
        public Task<Coverage> GetAsync(int id)
        {
            return Task.FromResult(new Coverage());
        }
    }
}
