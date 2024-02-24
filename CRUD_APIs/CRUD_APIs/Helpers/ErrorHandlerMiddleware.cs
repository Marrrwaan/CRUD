using System.Net;
using System.Text.Json;

namespace CRUD_APIs.Helpers
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;
        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
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
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                string message;

                _logger.LogError(error, "An error occurred processing the request.");

                switch (error)
                {
                    case UnAuthorizedException:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        message = error.Message;
                        break;
                    case ArgumentException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        message = error.Message;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        message = "Please re-try again, if the error persist please contact Administrator";
                        break;
                }
                var result = JsonSerializer.Serialize(new { Message = message });
                await response.WriteAsync(result);
            }
        }
    }
}
