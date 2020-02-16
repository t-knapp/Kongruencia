using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Kongruencia.Server;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS1998

namespace Kongruencia.Server {

	public class SQLiteRepository<T> : IRepository<T> where T : class {

		private DbSet<T> _entities;


		public SQLiteRepository( SQLiteContext context ) => _entities = context.Set<T>();


		public virtual async Task<T> GetAsync( object key, CancellationToken cancellationToken = default ) 
			=> await _entities.FindAsync( new[] { key }, cancellationToken );

		public virtual async Task<IEnumerable<T>> GetAsync( Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, CancellationToken cancellationToken = default ) {

			IQueryable<T> entities = _entities;
			if( filter != null )
				entities = entities.Where( filter );

			if( orderBy != null )
				return orderBy( entities ).ToArray();
			else
				return entities.ToArray();
		}

		public virtual async Task AddAsync( T entity, CancellationToken cancellationToken = default )
			=> await _entities.AddAsync( entity, cancellationToken );

		public virtual async Task RemoveAsync( object key, CancellationToken cancellationToken = default )
			=> _entities.Remove( await GetAsync( key, cancellationToken ) );
		public virtual async Task RemoveAsync( T entity, CancellationToken cancellationToken = default )
			=> _entities.Remove( entity );

		public virtual async Task UpdateAsync( T entity, CancellationToken cancellationToken = default ) {
			var entry = _entities.Attach( entity );
			entry.State = EntityState.Modified;
		}
	}
}

#pragma warning restore CS1998
