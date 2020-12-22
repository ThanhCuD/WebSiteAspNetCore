using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tadu.NetCore.Data.CustomModel;
using Tadu.NetCore.Data.Services;

namespace Tadu.NetCore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministrativeController : ControllerBase
    {
        private readonly ILogger<AdministrativeController> _logger;
        private readonly IAdministrativeService administrativeService;

        public AdministrativeController(ILogger<AdministrativeController> logger, IAdministrativeService  administrativeService)
        {
            _logger = logger;
            this.administrativeService = administrativeService;
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
                var message = "";
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;
                else
                    message = ex.Message;
                return BadRequest(new { message = "Error: " + message });
            }
        }

        [HttpGet("GetRoles")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
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
        [HttpGet("EditRole")]
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
