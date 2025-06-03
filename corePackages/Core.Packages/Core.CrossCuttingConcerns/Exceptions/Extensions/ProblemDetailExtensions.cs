using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.Exceptions.Extensions
{
    public static class ProblemDetailExtensions
    {
        public static string AsJson<TProblemDetails>(this TProblemDetails details)
            where TProblemDetails : ProblemDetails => JsonSerializer.Serialize(details);
    }
}
