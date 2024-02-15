using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using System.Security.Authentication;

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

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var statusCode = StatusCodes.Status500InternalServerError;
        var message = "Um erro inesperado aconteceu durante a execução.";

        switch (exception)
        {
            case SecurityTokenExpiredException:
                statusCode = StatusCodes.Status401Unauthorized;
                message = "Token de autenticação expirado.";
                break;
            case SecurityTokenException:
                statusCode = StatusCodes.Status401Unauthorized;
                message = "Token de autenticação inválido.";
                break;
            case AuthenticationException:
                statusCode = StatusCodes.Status401Unauthorized;
                message = "Erro de autenticação.";
                break;
            case UnauthorizedAccessException:
                statusCode = StatusCodes.Status403Forbidden;
                message = "Acesso negado.";
                break;
        }

        context.Response.StatusCode = statusCode;

        var errorResponse = new
        {
            StatusCode = statusCode,
            Message = message
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }
}
