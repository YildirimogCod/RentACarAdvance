﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class InternalServerErrorProblemDetails: ProblemDetails
    {
        public InternalServerErrorProblemDetails(string detail)
        {
            Title = "Internal Server Exception";
            Detail = "An unexpected error occurred. Please try again later.";
            Status = StatusCodes.Status500InternalServerError;
            Type = "https://Example.InternalServerErrorProblemDetails";
        }
    }
}
