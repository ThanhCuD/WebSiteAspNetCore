using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tadu.NetCore.Api.Custom;
using Tadu.NetCore.Data.CustomModel;
using Tadu.NetCore.Data.Services;

namespace Tadu.NetCore.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AdministrativeController : BaseApiController
    {
        private readonly ILogger<AdministrativeController> _logger;
        private readonly IAdministrativeService administrativeService;
        private readonly IUserService userService;

        public AdministrativeController(ILogger<AdministrativeController> logger, IAdministrativeService  administrativeService, IUserService userService)
        {
            _logger = logger;
            this.administrativeService = administrativeService;
            this.userService = userService;
        }

        [HttpPost("CreateRole")]
        [Custom]
        public async Task<IActionResult> CreateRole(CreateRoleModel model)
        {
            try
            {
                var result = await administrativeService.CreateRoleAsync(model);
                if (result.Succeeded)
                {
                    return Ok();
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

        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var auth = new CustomValidations(userService).ValidateCurrentUser(this.AuthHeader);
                if (!auth) return Unauthorized();

                var result = await administrativeService.GetRoleAsync();
                return Ok(result);
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
        [HttpPost("EditRole")]
        public async Task<IActionResult> EditRole(EditRoleModel model)
        {
            try
            {
                await administrativeService.EditRoleAsync(model);
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
