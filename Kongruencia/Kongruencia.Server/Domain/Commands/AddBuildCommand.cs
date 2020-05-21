using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;

namespace Kongruencia.Server.Commands {

    public class AddBuildCommand : IRequestHandler<AddBuildCommand.Input, Build> {

        public class Input : IRequest<Build> {
            public string ProductName { get; }
            public string BranchName { get; }

            public int BuildNumber { get; }
            public Coverage Coverage { get; }


            public Input( string productName, string branchName, int buildNumber, Coverage coverage ) {
                ProductName = productName ?? throw new ArgumentNullException( nameof( productName ) );
                BranchName = branchName ?? throw new ArgumentNullException( nameof( branchName ) );
                BuildNumber = buildNumber;
                Coverage = coverage ?? throw new ArgumentNullException( nameof( coverage ) );
            }
        }

        private readonly IMongoCollection<Product> _productCollection;


        public AddBuildCommand( IMongoCollection<Product> productCollection )
            => _productCollection = productCollection;


        public async Task<Build> Handle( Input request, CancellationToken cancellationToken ) {
            var product = await _productCollection
                .Find( p => p.ProductName == request.ProductName )
                .SingleOrDefaultAsync( cancellationToken );

            if( product is null )
                throw new ArgumentException( $"Product with name {request.ProductName} couldnt be found!" );

            var branch = product.Branches.SingleOrDefault( b => b.BranchName == request.BranchName );
            if( branch is null )
                throw new ArgumentException( $"Branch with name {request.BranchName} couldnt be found!" );

            var build = branch.AddBuild( request.BuildNumber, request.Coverage );
            await product.SaveAsync();
            return build;
        }
    }
}
