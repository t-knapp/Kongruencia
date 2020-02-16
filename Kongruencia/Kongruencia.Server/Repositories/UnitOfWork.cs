using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kongruencia.Server;

namespace Kongruencia.Server {

    public class UnitOfWork : IUnitOfWork {

        private readonly SQLiteContext _context;

        private readonly Lazy<IRepository<Product>> _productRepository;
        private readonly Lazy<IRepository<Branch>> _branchRepository;
        private readonly Lazy<IRepository<Build>> _buildRepository;
        private readonly Lazy<IRepository<Coverage>> _coverageRepository;

        public IRepository<Product> productRepository => _productRepository.Value;
        public IRepository<Branch> branchRepository => _branchRepository.Value;
        public IRepository<Build> buildRepository => _buildRepository.Value;
        public IRepository<Coverage> coverageRepository => _coverageRepository.Value;


        public UnitOfWork( SQLiteContext context ) {
            _context = context;

            //Remarks:
            //Repositories can be injected via the constructor
            //Pro: Repository implementation is controlled from bootstrapping code
            //Con: The constructor will explode
            _productRepository = new Lazy<IRepository<Product>>( () => new SQLiteRepository<Product>( _context ) );
            _branchRepository = new Lazy<IRepository<Branch>>( () => new SQLiteRepository<Branch>( _context ) );
            _buildRepository = new Lazy<IRepository<Build>>( () => new SQLiteRepository<Build>( _context ) );
            _coverageRepository = new Lazy<IRepository<Coverage>>( () => new SQLiteRepository<Coverage>( _context ) );
        }   


        public Task CompleteAsync() => _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
