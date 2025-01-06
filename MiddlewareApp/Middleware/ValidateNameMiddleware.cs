
using MiddlewareApp.Model.Entity;
using System.Text;

namespace MiddlewareApp.Middleware
{
    public class ValidateNameMiddleware : IMiddleware
    {
        private List<string> _invalidNames = new List<string>() {

            "POMERANIAN",
            "BRUNO",
            "VOLDEMORT",
            "RICKROLL"
        };

        private Boolean IsNameValid(Adventurer adventurerToCheck)
        {
            return !_invalidNames.Contains(adventurerToCheck.Name.ToUpper());
        }


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if ((context.Request.Path == "/adventurers") && (context.Request.Method == "POST"))
            {
                context.Request.EnableBuffering(); 
                Adventurer requestBody = await context.Request.ReadFromJsonAsync<Adventurer>();
                if (!IsNameValid(requestBody))
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsJsonAsync(new { message = "User name is not allowed" });
                    return;
                }
                context.Request.Body.Position = 0;

            }
            await next.Invoke(context);
        }
    }
    }
