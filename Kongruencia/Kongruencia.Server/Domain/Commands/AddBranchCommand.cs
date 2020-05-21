using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;

namespace Kongruencia.Server.Commands {

    public class AddBranchCommand : IRequestHandler<AddBranchCommand.Input, Branch> {

        public class Input : IRequest<Branch> {
            public string ProductName { get; }
            public string BranchName { get; }


            public Input( string productName, string branchName ) {
                ProductName = productName ?? throw new ArgumentNullException( nameof( productName ) );
                BranchName = branchName ?? throw new ArgumentNullException( nameof( branchName ) );
            }
        }

        private readonly IMongoCollection<Product> _productCollection;


        public AddBranchCommand( IMongoCollection<Product> productCollection )
            => _productCollection = productCollection;


        public async Task<Branch> Handle( Input request, CancellationToken cancellationToken ) {
            var product = await _productCollection
                .Find( p => p.ProductName == request.ProductName )
                .SingleOrDefaultAsync( cancellationToken );

            if( product is null )
                throw new ArgumentException( $"Product with name {request.ProductName} couldnt be found!" );

            var branch = product.AddBranch( request.BranchName );
            await product.SaveAsync( cancellationToken );
            return branch;
        }
    }
}
