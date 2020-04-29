using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kongruencia.Server;

namespace Kongruencia.Server {

    public class UnitOfWork : IUnitOfWork {

        private readonly SQLiteContext _context;

        private readonly Lazy<IRepository<Coverage>> _coverageRepository;

        public IRepository<Coverage> CoverageRepository => _coverageRepository.Value;


        public UnitOfWork( SQLiteContext context ) {
            _context = context;

            //Remarks:
            //Repositories can be injected via the constructor
            //Pro: Repository implementation is controlled from bootstrapping code
            //Con: The constructor will explode
            _coverageRepository = new Lazy<IRepository<Coverage>>( () => new SQLiteRepository<Coverage>( _context ) );
        }   

        public Task CompleteAsync() => _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
