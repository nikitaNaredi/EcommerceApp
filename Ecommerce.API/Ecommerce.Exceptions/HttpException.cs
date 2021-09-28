using System;
using System.Net;

namespace ECommerce.Exceptions
{
    public class HttpException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; }

        public HttpException() { }

        public HttpException(HttpStatusCode httpStatusCode, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
