using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces.IEFServices;
using BLL.DTO;

namespace VideoGameShop2.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IEFUserService efUserService;

        public UserController(IEFUserService EFUserService)
        { efUserService = EFUserService; }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterDTO user)
        {
            return Ok(await efUserService.Register(user));
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO user)
        {
                return Ok(await efUserService.Login(user));
        }

        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                return Ok(await efUserService.Logout());
            }
            catch
            { return StatusCode(404); }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] UserCreateDTO user)
        {
            try
            {
                await efUserService.Create(user);
                return StatusCode(201);
            }
            catch
            { return StatusCode(404); }
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] UserEditDTO user)
        {
            try
            {
                await efUserService.Edit(user);
                return StatusCode(204);
            }
            catch
            { return StatusCode(404); }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await efUserService.Delete(id);
                return StatusCode(204);
            }
            catch
            { return StatusCode(404); }
        }

        [HttpPut]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] UserChangePasswordDTO user)
        {
            try
            {
                await efUserService.ChangePassword(user);
                return StatusCode(204);
            }
            catch
            { return StatusCode(404); }
        }
    }
}
