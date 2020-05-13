using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using MongoDB.Driver;

namespace Kongruencia.Server.GraphQL {

    public class Query {

        [UseFiltering]
        public IQueryable<Product> Products( [Service] IMongoCollection<Product> products )
            => products.AsQueryable();

        public Task<Product> GetProduct( string id, [Service] IMongoCollection<Product> products )
            => products.Find( p => p.ID == id ).SingleOrDefaultAsync();
    }
}
