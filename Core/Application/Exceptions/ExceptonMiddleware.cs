using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ExceptonMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext htppContext, RequestDelegate next)
        {
            try
            {
                await next(htppContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(htppContext, ex);

            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            int statusCode = GetStatusCode(exception);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            if (exception.GetType() == typeof(ValidationException))
            {
                return httpContext.Response.WriteAsync(new ExcepitonModel
                {
                    Errors = ((ValidationException)exception).Errors.Select(x => x.ErrorMessage),
                    StatusCode = StatusCodes.Status400BadRequest

                }.ToString());
            }

            List<string> errors = new()
            {
$"Hata Mesajı:  {exception.Message}",
$"Mesaj Açıklaması:{exception.InnerException?.ToString()}"
            };

            return httpContext.Response.WriteAsync(new ExcepitonModel
            {
                Errors = errors,
                StatusCode = statusCode

            }.ToString());
        }

        private static int GetStatusCode(Exception exception) => exception switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            ValidationException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };
    }
}
