using Core.CrossCuttingConcerns.Exceptions.Handler;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HttpExceptionHandler _httpExceptionHandler;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
            _httpExceptionHandler = new HttpExceptionHandler();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context.Response,ex);
            }
        }

        public Task HandleExceptionAsync(HttpResponse response, Exception exception)
        {
            response.ContentType = "application/json";
            _httpExceptionHandler.Response = response;
            return _httpExceptionHandler.HandleExceptionAsync(exception);
        }

    }
}
