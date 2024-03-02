using BCI_Project.Models;
using BCI_Project.Services.GameService;
using BCI_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BCI_Project.Controllers
{
    //[Authorize]
    public class GameController : Controller
    {
        private readonly IGameService _gameservice;
        public GameController(IGameService gameservice)
        {
            _gameservice = gameservice;
        }

        [HttpGet(nameof(GetAllGames))]
        public async Task<IActionResult> GetAllGames()
        {
            var result = await _gameservice.GetAllGames();
            return Ok(result);
        }

        [HttpGet(nameof(GetGameById))]
        public async Task<IActionResult> GetGameById(Guid id)
        {
            var result = await _gameservice.GetGameById(id);
            return Ok(result);
        }

        [HttpPost(nameof(AddGame))]
        public async Task<IActionResult> AddGame([FromBody] GameVM _game)
        {
            var result = await _gameservice.AddGame(_game,User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return Ok(result);
        }

        [HttpPut(nameof(UpdateGame))]
        public async Task<IActionResult> UpdateGame([FromBody] GameVM _game)
        {
            var result = await _gameservice.UpdateGame(_game);
            return Ok(result);
        }

        [HttpDelete(nameof(DeleteGame))]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            var result = await _gameservice.DeleteGame(id);
            return Ok(result);
        }

    }
}
