using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;

namespace Kongruencia.Server.Commands {

    public class UploadCoverageCommand : IRequestHandler<UploadCoverageCommand.Input, Build> {

        public class Input : IRequest<Build> {
            public string ProductName { get; }
            public string BranchName { get; }

            public int BuildNumber { get; }
            public coverage Coverage { get; }


            public Input( string productName, string branchName, int buildNumber, coverage coverage ) {
                ProductName = productName ?? throw new ArgumentNullException( nameof( productName ) );
                BranchName = branchName ?? throw new ArgumentNullException( nameof( branchName ) );
                BuildNumber = buildNumber;
                Coverage = coverage ?? throw new ArgumentNullException( nameof( coverage ) );
            }
        }

        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;


        public UploadCoverageCommand( IMongoCollection<Product> productCollection, IMapper mapper )
            => ( _productCollection, _mapper ) = ( productCollection, mapper );


        public async Task<Build> Handle( Input request, CancellationToken cancellationToken ) {
            var product = await _productCollection
                .Find( p => p.ProductName == request.ProductName )
                .SingleOrDefaultAsync( cancellationToken );

            if( product is null ) {
                product = new Product(request.ProductName);
                await _productCollection.InsertOneAsync(product, null, cancellationToken);
            }

            var branch = product.Branches.SingleOrDefault( b => b.BranchName == request.BranchName );
            if( branch is null ) {
                branch = product.AddBranch(request.BranchName);
                await product.SaveAsync(cancellationToken);
            }

            var coverage = _mapper.Map<Coverage>(request.Coverage);
            var build = branch.AddBuild( request.BuildNumber, coverage );
            await product.SaveAsync();
            return build;
        }
    }
}
