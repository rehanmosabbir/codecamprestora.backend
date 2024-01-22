using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Exceptions
{
    public class DataAccessException : CommonException
    {
        public DataAccessException() : base() { }

        public DataAccessException(string message) : base(message) { }

        public DataAccessException(string message, Exception innerException) : base(message, innerException) { }
        public override HttpStatusCode StatusCode => HttpStatusCode.ServiceUnavailable;
    }
}
