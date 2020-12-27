using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Tadu.NetCore.Data.Services;

namespace Tadu.NetCore.Api.Custom
{
    public class ValidateCurrentUserMiddleware
    {

        private RequestDelegate _next;

        public ValidateCurrentUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                //This is important to call BEFORE invoking action to be able to read the body again afterwards
                context.Request.EnableBuffering(); // Use .EnableRewind() for ASP.NET Core 2.x

                var authS = context.Request.Headers["Authorization"];
                CustomValidations customValidations = new CustomValidations(userService);
                var auth = customValidations.ValidateCurrentUser(authS);
                if (auth)
                {
                    await _next(context); // The action in the controller will be called here
                }
            }
            else
            {
                await _next(context);
            }
        }
    }
}
