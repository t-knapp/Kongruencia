using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace Kongruencia.Server.GraphQL.Schema {

    public class QueryType : ObjectType<Query> {

        protected override void Configure( IObjectTypeDescriptor<Query> descriptor ) {
            
        }
    }
}
