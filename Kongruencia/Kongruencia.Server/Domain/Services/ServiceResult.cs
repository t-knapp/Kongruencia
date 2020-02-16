using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Server {

    public class ServiceResult<T>
    {
        public T result { get; }
        public ServiceError error { get; }

        public bool isSuccess => error is null;

        public ServiceResult(T result) => this.result = result;
        public ServiceResult(string message, Exception exception = null) => error = new ServiceError(message, exception);
    }
}
