using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces.IEFServices;
using DAL.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace VideoGameShop2.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        IEFGameService _efGameService;

        public GameController(IEFGameService efGameService)
        { _efGameService = efGameService; }

        [HttpGet("paged")]
        public async Task<IActionResult> Get([FromQuery] GameParameters gameParameters)
        {
            if (!gameParameters.ValidCostRange)
            { return BadRequest("Max value of cost cannot be less than min value of birth"); }

            var games = await _efGameService.GetGamesPartly(gameParameters);
            try { return Ok(games); }
            catch { return StatusCode(404); }
        }

        [HttpGet]
        public IActionResult GetView()
        {
            try { return View(); }
            catch { return StatusCode(404); }
        }



        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try { return Ok(await _efGameService.GetGameById(Id)); }
            catch { return StatusCode(404); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _efGameService.DeleteGame(Id);
                return StatusCode(204);
            }
            catch
            { return StatusCode(404); }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] GameDTO val)
        {
            try
            {
                await _efGameService.UpdateGame(val);
                return StatusCode(204);
            }
            catch
            { return StatusCode(404); }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GameDTO val)
        {
            try
            {
                return Ok(await _efGameService.AddGame(val));
            }
            catch
            { return StatusCode(404); }
        }

        [HttpGet("cheap")]
        public async Task<IActionResult> GetCheapest()
        {
            try { return Ok(await _efGameService.GetCheapestGame());}
            catch { return StatusCode(404); }
        }
    }
}