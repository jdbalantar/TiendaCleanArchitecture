using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using Transversal.Exceptions;

namespace Transversal.Middleware
{

    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ErrorHandlingMiddleware> logger)
        {
            string? message = null;
            object data = new object();

            switch (ex)
            {
                case RestException re:
                    logger.LogError(ex, "Error: ");
                    message = re.message;
                    data = ex.Data;
                    context.Response.StatusCode = (int)re.code;
                    break;
                case Exception e:
                    logger.LogError(ex, "Internal Server Error: ");
                    message = string.IsNullOrEmpty(e.Message) ? "Error: " : e.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";

            if (message != null)
            {
                var result = JsonSerializer.Serialize(new { message, data });
                await context.Response.WriteAsync(result);
            }
        }
    }
}


