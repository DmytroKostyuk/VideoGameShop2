using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces.IEFServices;
using DAL.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace VideoGameShop2.Controllers
{
    [Route("api/[controller]")]
    public class DeveloperController : Controller
    {
        IEFDeveloperService _efDeveloperService;

        public DeveloperController(IEFDeveloperService efDeveloperService)
        { _efDeveloperService = efDeveloperService; }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DeveloperParameters developerParameters)
        {
            var developers = await _efDeveloperService.GetDevelopersPartly(developerParameters);
            try { return Ok(developers); }
            catch { return StatusCode(404); }
        }

        [HttpGet("id/{id}")]
       public async Task<IActionResult> Get(int Id)
        {
            try { return Ok(await _efDeveloperService.GetDeveloperById(Id)); }
            catch { return StatusCode(404); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try 
            { 
                await _efDeveloperService.DeleteDeveloper(Id);
                return StatusCode(204);
            }
            catch
            { return StatusCode(404); }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DeveloperDTO val)
        {
            try
            {
                await _efDeveloperService.UpdateDeveloper(val);
                return StatusCode(204);
            }
            catch
            { return StatusCode(404); }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DeveloperDTO val)
        {
            try
            {
                return Ok(await _efDeveloperService.AddDeveloper(val));
            }
            catch
            { return StatusCode(404); }
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try { return Ok(await _efDeveloperService.GetDeveloperByName(name)); }
            catch { return StatusCode(404); }
        }
    }
}