using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces.IEFServices;
using BLL.DTO;
using System.Collections.Generic;

namespace VideoGameShop2.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IEFRoleService eFRoleService;

        public RoleController(IEFRoleService EFRoleService)
        { eFRoleService = EFRoleService; }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody]RoleDTO role)
        {
            try
            {
                return Ok(await eFRoleService.CreateRole(role));
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpPost]
        [Route("AppointRole")]
        public async Task<IActionResult> AppointRole([FromQuery]int id, [FromQuery]string role)
        {
            try
            {
                await eFRoleService.AppointRole(id,role);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(404);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRoleById([FromQuery]int id)
        {
            try
            {
                return Ok(await eFRoleService.GetRoleById(id));
            }
            catch { return StatusCode(404); }
        }

    }
}
