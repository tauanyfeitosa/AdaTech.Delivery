
using System.Security.Authentication;


namespace AdaTech.Delivery.WebAPI.Utilities.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            int originalStatusCode = httpContext.Response.StatusCode;

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo de errado aconteceu: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var statusCode = exception switch
            {
                KeyNotFoundException _ => StatusCodes.Status404NotFound,
                AuthenticationException _ => StatusCodes.Status401Unauthorized,
                UnauthorizedAccessException _ => StatusCodes.Status403Forbidden,
                _ => StatusCodes.Status500InternalServerError
            };

            var message = exception.Message;

            context.Response.StatusCode = statusCode;

            var errorResponse = new
            {
                StatusCode = statusCode,
                Message = message
            };

            await context.Response.WriteAsJsonAsync(errorResponse);
        }

    }
}

