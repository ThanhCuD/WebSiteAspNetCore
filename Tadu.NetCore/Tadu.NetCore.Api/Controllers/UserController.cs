using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tadu.NetCore.Data.Services;

namespace Tadu.NetCore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("CreateUser")]
        public IActionResult CreateUser(string userName, string password)
        {
            try
            {
                var result = _userService.CreateUser(userName, password);
                if (result.Status == Data.ApiResultEnum.NothingChange)
                {
                    return BadRequest(new { message = "Error: " + result.Message });
                }
                return Ok();
            }
            catch (Exception ex)
            {
                var message = "";
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;
                else
                    message = ex.Message;
                return BadRequest(new { message = "Error: " + message });
            }
        }
        [HttpGet("Login")]
        public IActionResult Login(string userName, string password)
        {
            try
            {
                var result = _userService.Login(userName, password);
                if (result.Status == Data.ApiResultEnum.NothingChange)
                {
                    return BadRequest(new { message = "Error: " + result.Message });
                }
                return Ok();
            }
            catch (Exception ex)
            {
                var message = "";
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;
                else
                    message = ex.Message;
                return BadRequest(new { message = "Error: " + message });
            }
        }
    }
}
