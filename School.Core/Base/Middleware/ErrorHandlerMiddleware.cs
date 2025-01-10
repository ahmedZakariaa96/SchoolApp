using Microsoft.AspNetCore.Http;
using School.Application.Base.Shared;
using System.Text.Json;

namespace School.Application.Base.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var message = error.Message;
                message += error.InnerException == null ? "" : "\n" + error.InnerException.Message;
                var responseModel = Result<HttpResponse>.Falid(null, message);

                var exValidationException = error as FluentValidation.ValidationException;
                if (exValidationException != null)
                {
                    responseModel = Result<HttpResponse>.Info(null, StatusResult.ValidationException, message, StatusCodes.Status417ExpectationFailed);
                    responseModel.ValidationsErrors = exValidationException.Errors.ToList();
                }

                var result = JsonSerializer.Serialize(responseModel);


                await response.WriteAsync(result);
            }
        }
    }

}
