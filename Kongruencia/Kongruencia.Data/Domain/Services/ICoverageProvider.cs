using Kongruencia.Data.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kongruencia.Data.Domain.Services
{
    public interface ICoverageProvider
    {
        Task<Coverage> GetAsync(int id);
    }
}
