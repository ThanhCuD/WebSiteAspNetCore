using Microsoft.AspNetCore.Mvc;
using Tadu.NetCore.Api.Custom;

namespace Tadu.NetCore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseApiController : ControllerBase
    {
        private string _authHeader;
        protected string AuthHeader => _authHeader ??= Request.Headers["Authorization"];
    }
}
