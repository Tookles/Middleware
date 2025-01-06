
using Microsoft.AspNetCore.Identity.Data;

namespace MiddlewareApp.Middleware
{
    public class LoggerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            LogRequest(context); 

            await next.Invoke(context);

            LogResponse(context);

        }


        public void LogRequest(HttpContext context)
        {
            string newLog = $"{DateTime.UtcNow}: {context.Request.Method} {context.Request.Path} \n"; 
            File.AppendAllText("ServerLogs.txt", newLog);
        }

        public void LogResponse(HttpContext context)
        {
            string newLog = $"{DateTime.UtcNow}: {context.Response.StatusCode} \n";
            File.AppendAllText("ServerLogs.txt", newLog);
        }

    }



}
