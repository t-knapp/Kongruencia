using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Server {

    public static class IListExtensions {

        public static T AddAndReturn<T>( this IList<T> list, T item ) {
            list.Add( item );
            return item;
        }
    }
}
