using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class ValidationProblemDetails : ProblemDetails
    {
        public IEnumerable<ValidationExceptionModel> Errors { get; init; }

        public ValidationProblemDetails(IEnumerable<ValidationExceptionModel> errors)
        {
            Title = "Validation Error";
            Detail = "One or more validation errors occurred.";
            Status = StatusCodes.Status400BadRequest;
            Type = "https://Example.ValidationProblemDetails";
            Errors = errors ?? throw new ArgumentNullException(nameof(errors));
        }
    }
}
