using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domain.Services
{
    public class ServiceError
    {

        public string message { get; private set; }
        public Exception exception { get; private set; }


        public ServiceError(string message, Exception exception = null)
        {
            this.message = message;
            this.exception = exception;
        }


        public override string ToString() => message + Environment.NewLine + exception?.ToString() ?? "";
    }
}
