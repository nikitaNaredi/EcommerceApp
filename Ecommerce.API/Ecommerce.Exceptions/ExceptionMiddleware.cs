using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using ECommerce.Exceptions;
using ECommerce.Exceptions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ecommerce.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, Func<Task> next)
        {
            try
            {
                await next.Invoke().ConfigureAwait(false);
            }
            catch (HttpException ex)
            {
                _logger.LogWarning(ex, "The ErrorWrappingMiddleware forwarded a HttpException.");

                await WriteContent(context, ex.HttpStatusCode, new ErrorResponse()
                {
                    Code = (int)ex.HttpStatusCode,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The ErrorWrappingMiddleware caught an unhandled exception. This is a bug.");

                await WriteContent(context, HttpStatusCode.InternalServerError, new ErrorResponse()
                {
                    Code = 500,
                    Message = "An unknown error occurred."
                });
            }
        }

        private async Task WriteContent(HttpContext context, HttpStatusCode httpStatusCode, ErrorResponse error)
        {
            context.Response.StatusCode = (int)httpStatusCode;
            context.Response.Headers.Add("Content-Type", MediaTypeNames.Application.Json);
            await context.Response.WriteAsync(JsonConvert.SerializeObject(error));
        }
    }
}
