using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domain.Services
{
    public class ServiceResult<T>
    {

        public T result { get; private set; }
        public ServiceError error { get; private set; }

        public bool isSuccess => error == null;


        public ServiceResult(T result) => this.result = result;
        public ServiceResult(string message, Exception exception = null) => error = new ServiceError(message, exception);
    }
}
