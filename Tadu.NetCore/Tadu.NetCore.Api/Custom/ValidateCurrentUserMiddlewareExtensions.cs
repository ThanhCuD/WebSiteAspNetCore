using Microsoft.AspNetCore.Builder;
using Tadu.NetCore.Api.Custom;

public static class ValidateCurrentUserMiddlewareExtensions
{
    public static IApplicationBuilder UseValidateCurrentUser(
           this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ValidateCurrentUserMiddleware>();
    }
}