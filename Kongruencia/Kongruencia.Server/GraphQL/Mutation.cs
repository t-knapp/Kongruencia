using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kongruencia.Server.Commands;
using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;

namespace Kongruencia.Server.GraphQL {

    public class Mutation {

        private readonly IMediator _mediator;


        public Mutation( IMediator mediator )
            => _mediator = mediator;


        public Task<Product> CreateProduct( string productName )
            => _mediator.Send( new AddProductCommand.Input( productName ) );

        public Task<Branch> CreateBranch( string productName, string branchName )
            => _mediator.Send( new AddBranchCommand.Input( productName, branchName ) );

        public Task<Build> CreateBuild( AddBuildCommand.Input build )
            => _mediator.Send( build );

        public Task<Build> UploadCoverageFile( UploadCoverageCommand.Input coverage )
            => _mediator.Send( coverage );
    } 
}
