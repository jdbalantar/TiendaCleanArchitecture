using System.Net;

namespace Transversal.Exceptions
{
    public class RestException : Exception
    {
        public HttpStatusCode code;
        public string message;
        public object? data;
        public RestException(HttpStatusCode code, string message, object? data = null)
        {
            this.code = code;
            this.message = message;
            this.data = data;
        }
    }
}
