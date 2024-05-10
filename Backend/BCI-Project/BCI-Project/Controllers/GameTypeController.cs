using BCI_Project.Models;
using BCI_Project.Services.GameTypeService;
using BCI_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BCI_Project.Controllers
{
    [AllowAnonymous]
    public class GameTypeController : Controller
    {
        private readonly IGameTypeService _gametypeservice;
        public GameTypeController(IGameTypeService gametypeservice)
        {
            _gametypeservice = gametypeservice;
        }

        [HttpGet(nameof(GetAllGameTypes))]
        public async Task<IActionResult> GetAllGameTypes()
        {
            var result = await _gametypeservice.GetAllGameTypes();
            return Ok(result);
        }

        [HttpGet(nameof(GetGameTypeById))]
        public async Task<IActionResult> GetGameTypeById(Guid id)
        {
            var result = await _gametypeservice.GetGameTypeById(id);
            return Ok(result);
        }

        [HttpPost(nameof(AddGameType))]
        public async Task<IActionResult> AddGameType([FromBody] GameTypeVM _gametype)
        {
            var result = await _gametypeservice.AddGameType(_gametype);
            return Ok(result);
        }

        [HttpPut(nameof(UpdateGameType))]
        public async Task<IActionResult> UpdateGameType([FromBody] GameTypeVM _gametype)
        {
            var result = await _gametypeservice.UpdateGameType(_gametype);
            return Ok(result);
        }

        [HttpDelete(nameof(DeleteGameType))]
        public async Task<IActionResult> DeleteGameType(Guid id)
        {
            var result = await _gametypeservice.DeleteGameType(id);
            return Ok(result);
        }
    }
}
