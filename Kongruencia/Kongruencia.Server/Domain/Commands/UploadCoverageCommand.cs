using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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


        public UploadCoverageCommand( IMongoCollection<Product> productCollection )
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

            //TODO: Could use automapper to do this... Ez Clap
            var project = request.Coverage.project;
            var coverage = new Coverage {
                Timestamp = DateTime.FromFileTimeUtc( long.Parse( project.timestamp ) ),
                Statements = new Coverage.Metric( int.Parse( project.metrics.statements ), int.Parse( project.metrics.coveredstatements ) ),
                Conditionals = new Coverage.Metric( int.Parse( project.metrics.conditionals ), int.Parse( project.metrics.coveredconditionals ) ),
                Methods = new Coverage.Metric( int.Parse( project.metrics.methods ), int.Parse( project.metrics.coveredmethods ) ),
                Elements = new Coverage.Metric( int.Parse( project.metrics.elements ), int.Parse( project.metrics.coveredelements ) )
            };
            var build = branch.AddBuild( request.BuildNumber, coverage );
            await product.SaveAsync();
            return build;
        }
    }
}
