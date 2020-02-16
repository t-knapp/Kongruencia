using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kongruencia.Server;

namespace Kongruencia.Server {

    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> productRepository { get; }
        IRepository<Branch> branchRepository { get; }
        IRepository<Build> buildRepository { get; }

        IRepository<Coverage> coverageRepository { get; }
        //IRepository<Package> productRepository { get; }
        //IRepository<File> productRepository { get; }


        Task CompleteAsync();
    }
}
