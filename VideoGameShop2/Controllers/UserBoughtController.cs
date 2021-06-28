using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces.IEFServices;
using Microsoft.AspNetCore.Mvc;

namespace VideoGameShop2.Controllers
{
    [Route("api/[controller]")]
    public class UserBoughtController : Controller
    {
        IEFUserBoughtService _efUserBoughtService;

        public UserBoughtController(IEFUserBoughtService efUserBoughtService)
        { _efUserBoughtService = efUserBoughtService; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try { return Ok(await _efUserBoughtService.GetAllUserBoughts()); }
            catch { return StatusCode(404); }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try { return Ok(await _efUserBoughtService.GetUserBoughtById(Id)); }
            catch { return StatusCode(404); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _efUserBoughtService.DeleteUserBought(Id);
                return StatusCode(204);
            }
            catch
            { return StatusCode(404); }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserBoughtDTO val)
        {
            try
            {
                await _efUserBoughtService.UpdateUserBought(val);
                return StatusCode(204);
            }
            catch
            { return StatusCode(404); }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserBoughtDTO val)
        {
            try
            {
                await _efUserBoughtService.AddUserBought(val);
                return StatusCode(201);
            }
            catch
            { return StatusCode(404); }
        }
    }
}