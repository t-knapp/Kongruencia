using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Server {

    public class ServiceError
    {

        public string message { get; }
        public Exception exception { get; }


        public ServiceError( string message, Exception exception = null )
            => (this.message, this.exception) = (message, exception);


        public override string ToString() => message + Environment.NewLine + exception?.ToString() ?? "";
    }
}
