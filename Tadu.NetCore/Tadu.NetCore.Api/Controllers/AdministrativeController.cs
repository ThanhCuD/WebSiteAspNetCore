using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Tadu.NetCore.Api.Extensions;
using Tadu.NetCore.Data.CustomModel;
using Tadu.NetCore.Data.Services;

namespace Tadu.NetCore.Api.Controllers
{
    [ApiController]
    [AuthorizeExtention(Roles = "Administrative")]
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
                this.log.Error(string.Format(Conts.Conts.ApiErrorMessageLog, ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName), ex);
                return BadRequest(new { message = Conts.Conts.ApiErrorMessageResponse });
            }
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var result = await administrativeService.GetRoleAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.log.Error(string.Format(Conts.Conts.ApiErrorMessageLog, ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName), ex);
                return BadRequest(new { message = Conts.Conts.ApiErrorMessageResponse });
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
                this.log.Error(string.Format(Conts.Conts.ApiErrorMessageLog, ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName), ex);
                return BadRequest(new { message = Conts.Conts.ApiErrorMessageResponse });
            }
        }

        [HttpPost("DeleteRole")]
        public async Task<IActionResult> DeleteRole(DeleteRoleModel model)
        {
            try
            {
                await administrativeService.DeleteRoleAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                this.log.Error(string.Format(Conts.Conts.ApiErrorMessageLog,ControllerContext.ActionDescriptor.ControllerName,ControllerContext.ActionDescriptor.ActionName), ex);
                return BadRequest(new { message = Conts.Conts.ApiErrorMessageResponse });
            }
        }
    }
}
