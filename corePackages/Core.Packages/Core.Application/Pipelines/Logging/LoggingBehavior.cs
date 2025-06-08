using System.Text.Json;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.SeriLog;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Pipelines.Logging
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ILoggableRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LoggerServiceBase _loggerService;
        public LoggingBehavior(IHttpContextAccessor httpContextAccessor, LoggerServiceBase loggerService)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _loggerService = loggerService ?? throw new ArgumentNullException(nameof(loggerService));
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            List<LogParameter> parameters = new()
            {
                new LogParameter { Type = request.GetType().Name, Value = request },
            };
            LogDetail logDetail = new LogDetail(
                fullName: request.GetType().FullName ?? string.Empty,
                methodName: request.GetType().Name,
                user: _httpContextAccessor.HttpContext?.User.Identity?.Name ?? "Anonymous",
                parameters: parameters
            );
            _loggerService.Information(JsonSerializer.Serialize(logDetail));
            return await next();

        }
    }
}
