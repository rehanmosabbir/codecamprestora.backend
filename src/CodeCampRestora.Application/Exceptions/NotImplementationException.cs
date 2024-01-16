using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Exceptions
{
    public class NotImplementationException : CommonException
    {
        public NotImplementationException() : base() { }

        public NotImplementationException(string message) : base(message) { }

        public NotImplementationException(string message, Exception innerException) : base(message, innerException) { }
        public override HttpStatusCode StatusCode => HttpStatusCode.NotImplemented;
    }
}
