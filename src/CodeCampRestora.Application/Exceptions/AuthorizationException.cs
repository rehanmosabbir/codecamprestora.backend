using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Exceptions
{
    public class AuthorizationException : CommonException
    {
        public AuthorizationException() : base() { }

        public AuthorizationException(string message) : base(message) { }

        public AuthorizationException(string message, Exception innerException) : base(message, innerException) { }
        public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
    }
}
