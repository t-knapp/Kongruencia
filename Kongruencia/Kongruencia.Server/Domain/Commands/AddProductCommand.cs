using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver;

namespace Kongruencia.Server.Commands {

    public class AddProductCommand : IRequestHandler<AddProductCommand.Input, Product> {

        public class Input : IRequest<Product> {
            public string ProductName { get; }


            public Input( string productName ) 
                => ProductName = productName ?? throw new ArgumentNullException( nameof( productName ) );
        }

        private readonly IMongoCollection<Product> _productCollection;


        public AddProductCommand( IMongoCollection<Product> productCollection )
            => _productCollection = productCollection;


        public async Task<Product> Handle( Input request, CancellationToken cancellationToken ) {
            var product = new Product( request.ProductName );
            await _productCollection.InsertOneAsync( product, null, cancellationToken );
            return product;
        }
    }
}
