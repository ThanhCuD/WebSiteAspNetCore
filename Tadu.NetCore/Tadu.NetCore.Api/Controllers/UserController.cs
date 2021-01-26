using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Tadu.NetCore.Api.Extensions;
using Tadu.NetCore.Data.CustomModel;
using Tadu.NetCore.Data.Model;
using Tadu.NetCore.Data.Services;

namespace Tadu.NetCore.Api.Controllers
{
    [ApiController]
    [AuthorizeExtention]
    [Route("[controller]")]
    public class UserController : BaseApiController
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
                this.log.Error(string.Format(Conts.Conts.ApiErrorMessageLog, ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName), ex);
                return BadRequest(new { message = Conts.Conts.ApiErrorMessageResponse });
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                var result = await _userService.Login(model);
                if (result!=null)
                {
                    return Ok(result);
                }
                var mess = "Error : Invalid Login Attempt";
                return BadRequest(new { message = mess });
            }
            catch (Exception ex)
            {
                this.log.Error(string.Format(Conts.Conts.ApiErrorMessageLog, ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName), ex);
                return BadRequest(new { message = Conts.Conts.ApiErrorMessageResponse });
            }
        }
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var response =  await _userService.Authenticate(model);

            if (response==null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPost("Logout")]
        public async Task Logout()
        {
            await _userService.Logout();
        }
    }
}
