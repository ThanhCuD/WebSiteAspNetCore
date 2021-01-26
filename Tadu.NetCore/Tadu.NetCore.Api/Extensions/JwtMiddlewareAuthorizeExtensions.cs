using Microsoft.AspNetCore.Builder;
using Tadu.NetCore.Api.Extensions;

public static class JwtMiddlewareAuthorizeExtensions
{
    public static IApplicationBuilder UseJwtMiddlewareAuthorize(
           this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<JwtMiddleware>();
    }
}