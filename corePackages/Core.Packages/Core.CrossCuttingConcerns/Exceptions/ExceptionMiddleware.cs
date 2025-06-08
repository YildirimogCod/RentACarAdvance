using System.Text.Json;
using Core.CrossCuttingConcerns.Exceptions.Handler;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.SeriLog;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HttpExceptionHandler _httpExceptionHandler;
        private readonly LoggerServiceBase _loggerService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExceptionMiddleware(RequestDelegate next, LoggerServiceBase loggerService, IHttpContextAccessor httpContextAccessor)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _httpExceptionHandler = new HttpExceptionHandler();
            _loggerService = loggerService ?? throw new ArgumentNullException(nameof(loggerService));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await LogException(context, ex);
                await HandleExceptionAsync(context.Response,ex);
            }
        }

        private Task LogException(HttpContext context, Exception ex)
        {
            List<LogParameter> logParameters = new()
            {
                new LogParameter { Type = context.GetType().Name, Value = ex.ToString() }
            };
            LogDetailWithException logDetail = new LogDetailWithException(
                fullName: context.GetType().FullName ?? string.Empty,
                methodName: context.Request.Method,
                user: _httpContextAccessor.HttpContext?.User.Identity?.Name ?? "Anonymous",
                parameters: logParameters,
                exceptionMessage: ex.Message
            );
            _loggerService.Error(JsonSerializer.Serialize(logDetail));
            return Task.CompletedTask;
        }

        public Task HandleExceptionAsync(HttpResponse response, Exception exception)
        {
            response.ContentType = "application/json";
            _httpExceptionHandler.Response = response;
            return _httpExceptionHandler.HandleExceptionAsync(exception);
        }

    }
}
