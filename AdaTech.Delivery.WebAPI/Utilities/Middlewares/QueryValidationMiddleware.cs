using System.Text.Json;

namespace AdaTech._LoginMiddleware.WebAPI.Utilities.Middleware
{
    public class QueryValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public QueryValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var query = context.Request.Query;

            if (context.Request.Path.Value.EndsWith("/byCPF", StringComparison.OrdinalIgnoreCase) && 
                (!query.ContainsKey("cpf")))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(new { Message = "O parâmetro 'cpf' é obrigatório." }));
                return;
            }
            
            if (context.Request.Path.Value.EndsWith("/testMiddleware", StringComparison.OrdinalIgnoreCase) && 
                (!query.ContainsKey("test")))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(new { Message = "O parâmetro 'test' é obrigatório e deve ser um número inteiro." }));
                return;
            }

            if (context.Request.Path.Value.EndsWith("/login", StringComparison.OrdinalIgnoreCase) && ((!query.ContainsKey("cpf") || string.IsNullOrWhiteSpace(query["cpf"])) ||
                !query.ContainsKey("senha") || string.IsNullOrWhiteSpace(query["senha"])))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(new { Message = "Os parâmetros de consulta 'login' e 'senha' são obrigatórios." }));
                return;
            }

            if (context.Request.Path.Value.EndsWith("/logout", StringComparison.OrdinalIgnoreCase) && 
                               (!query.ContainsKey("cpf") || string.IsNullOrWhiteSpace(query["cpf"])))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(new { Message = "O parâmetro 'cpf' é obrigatório." }));
                return;
            }

            await _next(context);
        }
    }
}
