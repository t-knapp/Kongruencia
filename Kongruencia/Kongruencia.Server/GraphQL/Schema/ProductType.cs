using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace Kongruencia.Server.GraphQL.Schema {

    public class ProductType : ObjectType<Product> {

        protected override void Configure( IObjectTypeDescriptor<Product> descriptor ) {

            descriptor
                .Field( p => p.ID )
                .Name( "id" );

            descriptor
                .Ignore( p => p.ModifiedOn );
        }
    }
}
