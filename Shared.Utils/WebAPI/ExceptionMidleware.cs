using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Shared.Utils.Exceptions;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shared.Utils.WebAPI
{
    public class ExceptionMidleware
    {
        private readonly ILogger<ExceptionMidleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionMidleware(RequestDelegate next, ILogger<ExceptionMidleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BusinessRuleValidationException ex)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.BadRequest;

                var result = JsonSerializer.Serialize(ex.ResponseModel);
                await response.WriteAsync(result);

            }
        }
    }
}