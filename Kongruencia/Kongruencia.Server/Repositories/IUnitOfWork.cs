using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kongruencia.Server;

namespace Kongruencia.Server {

    public interface IUnitOfWork : IDisposable
    {
        IRepository<Coverage> coverageRepository { get; }

        Task CompleteAsync();
    }
}
