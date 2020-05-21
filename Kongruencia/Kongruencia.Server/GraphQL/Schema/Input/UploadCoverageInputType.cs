using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using Kongruencia.Server.Commands;

namespace Kongruencia.Server.GraphQL.Schema {

    public class UploadCoverageInputType : InputObjectType<UploadCoverageCommand.Input> {

        protected override void Configure( IInputObjectTypeDescriptor<UploadCoverageCommand.Input> descriptor ) {
            descriptor
                .Name( "UploadCoverageInput" );
        }
    }
}
