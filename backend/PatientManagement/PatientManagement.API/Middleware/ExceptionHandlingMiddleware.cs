using Microsoft.Data.SqlClient;
using Serilog;
using System.Net;
using System.Text.Json;

namespace PatientManagement.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unhandled exception occurred.");

                context.Response.ContentType = "application/json";

                int statusCode = (int)HttpStatusCode.InternalServerError;
                string message = ex.Message;

                if (ex is SqlException sqlException)
                {
                    statusCode = (int)HttpStatusCode.BadRequest;

                    message = sqlException.Number switch
                    {
                        2627 => "Duplicate record. Email or Mobile Number already exists.",
                        2601 => "Duplicate record. Email or Mobile Number already exists.",
                        _ => sqlException.Message
                    };
                }

                context.Response.StatusCode = statusCode;

                var response = new
                {
                    Success = false,
                    Message = message
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
