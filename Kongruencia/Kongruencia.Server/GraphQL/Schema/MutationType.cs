using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace Kongruencia.Server.GraphQL.Schema {

    public class MutationType : ObjectType<Mutation> {

        protected override void Configure( IObjectTypeDescriptor<Mutation> descriptor ) {

           
        }
    }
}
