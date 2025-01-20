using SepTask.Api.Response;
using SepTask.Application.Exceptions;
using SepTask.Shared.Abstractions.Exceptions;
using System.Text.Json;

namespace SepTask.Api.Middleware
{
    public sealed class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        private static readonly string ContentType = "application/json";


        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException e)
            {
                await HandleValidationException(context, e);
            }
            catch (SepTaskException e)
            {
                await HandleApplicationException(context, e);
            }
    
        }
        private static async Task HandleValidationException(HttpContext httpContext, ValidationException validationException)
        {
            var messages = new List<Message>();
            var errors = GetErrors(validationException);

            messages.AddRange(errors.Select(i => new Message($"{i.Key} : {i.Value[0]}", MessageCode.Error)));

            var response = ApiResponse.Error(GetStatusCode(validationException), messages);

            httpContext.Response.ContentType = ContentType;

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response, options));
        }
        private static async Task HandleApplicationException(HttpContext httpContext, SepTaskException sepTaskException)
        {
            var response = ApiResponse.Error(GetStatusCode(sepTaskException),
            [
                new(sepTaskException.Message,MessageCode.Error)
            ]);
            httpContext.Response.ContentType = ContentType;
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response, options));
        }

        private static int GetStatusCode(Exception exception) =>
                                                            exception switch
                                                            {
                                                                SepTaskException => StatusCodes.Status400BadRequest,
                                                                ValidationException => StatusCodes.Status400BadRequest,
                                                                _ => StatusCodes.Status500InternalServerError
                                                            };


        private static IReadOnlyDictionary<string, string[]> GetErrors(Exception exception)
        {
            IReadOnlyDictionary<string, string[]> errors = null;

            if (exception is ValidationException validationException)
            {
                errors = validationException.ErrorsDictionary;
            }
            return errors;
        }
    }
}
