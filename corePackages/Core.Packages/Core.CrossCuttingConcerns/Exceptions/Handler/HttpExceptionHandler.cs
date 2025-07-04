﻿using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;


namespace Core.CrossCuttingConcerns.Exceptions.Handler
{
    public class HttpExceptionHandler:ExceptionHandler
    {
        private HttpResponse? _httpResponse;
        public HttpResponse Response
        {
            get => _httpResponse ?? throw new ArgumentException();
            set => _httpResponse = value;

        }
        protected override Task HandleException(BusinessException businessException)
        {
           Response.StatusCode = StatusCodes.Status400BadRequest;
           string details = new BusinessProblemDetails(businessException.Message).AsJson();
           return Response.WriteAsync(details);
        }

        protected override Task HandleException(ValidationException validationException)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            string details = new ValidationProblemDetails(validationException.Errors).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandleException(Exception exception)
        {
            Response.StatusCode = StatusCodes.Status500InternalServerError;
            string details = new InternalServerErrorProblemDetails(exception.Message).AsJson();
            return Response.WriteAsync(details);
        }
        
    }
}
