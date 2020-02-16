using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Kongruencia.Server {

	public interface IRepository<T> {

		Task<T> GetAsync( object key, CancellationToken cancellationToken = default );
		Task<IEnumerable<T>> GetAsync( Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, CancellationToken cancellationToken = default );

		Task AddAsync( T entity, CancellationToken cancellationToken = default );
		Task RemoveAsync( object key, CancellationToken cancellationToken = default );
		Task RemoveAsync( T entity, CancellationToken cancellationToken = default );
		Task UpdateAsync( T entity, CancellationToken cancellationToken = default );	
	}
}
