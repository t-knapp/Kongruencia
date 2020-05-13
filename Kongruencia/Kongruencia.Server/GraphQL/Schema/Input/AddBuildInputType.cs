using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using Kongruencia.Server.Commands;

namespace Kongruencia.Server.GraphQL.Schema {

    public class AddBuildInputType : InputObjectType<AddBuildCommand.Input> {

        protected override void Configure( IInputObjectTypeDescriptor<AddBuildCommand.Input> descriptor ) {
            descriptor
                .Name( "AddBuildInput" );
        }
    }
}
