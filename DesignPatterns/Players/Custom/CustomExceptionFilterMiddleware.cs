using Logger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Players.Custom
{
    public class CustomExceptionFilterMiddleware
    {
        private readonly RequestDelegate next;
        private ILog _ILog;

        public CustomExceptionFilterMiddleware(RequestDelegate next)
        {
            this.next = next;
            _ILog = Logger.Log.getInstance();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _ILog.LogException(context.ToString());

                // Customize the error response to the client
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("An error occurred. Please try again later.");
            }
        }
    }
}
