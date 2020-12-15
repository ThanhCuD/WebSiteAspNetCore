using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tadu.NetCore.Data.CustomModel;
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

        [HttpPost("RegisterUser")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser(RegisterUserModel model)
        {
            try
            {
                var result = await _userService.RegisterUserAsync(model);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                var mess = "Error :";
                foreach (var item in result.Errors)
                {
                    mess += item.Description;
                }
                return BadRequest(new { message = mess });
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

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                var result = await _userService.Login(model);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                var mess = "Error : Invalid Login Attempt";
                return BadRequest(new { message = mess });
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

        [HttpPost("Logout")]
        public async Task Logout()
        {
            await _userService.Logout();
        }
    }
}
