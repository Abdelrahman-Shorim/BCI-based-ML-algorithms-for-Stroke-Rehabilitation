using BCI_Project.Services.GameMovementService;
using BCI_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BCI_Project.Controllers
{
    public class GameMovementController : Controller
    {
        private readonly IGameMovementService _gamemovementservice;
        public GameMovementController(IGameMovementService gamemovementservice)
        {
            _gamemovementservice = gamemovementservice;
        }

        [HttpGet(nameof(GetAllGameMovements))]
        public async Task<IActionResult> GetAllGameMovements()
        {
            var result = await _gamemovementservice.GetAllGameMovements();
            return Ok(result);
        }

        [HttpGet(nameof(GetAllGameMovementsByGameId))]
        public async Task<IActionResult> GetAllGameMovementsByGameId(Guid id)
        {
            var result = await _gamemovementservice.GetAllGameMovementsByGameId(id);
            return Ok(result);
        }

        [HttpGet(nameof(GetGameMovementById))]
        public async Task<IActionResult> GetGameMovementById(Guid id)
        {
            var result = await _gamemovementservice.GetGameMovementById(id);
            return Ok(result);
        }

        [HttpPost(nameof(AddGameMovement))]
        public async Task<IActionResult> AddGameMovement([FromBody] GameMovementVM _gamemovement)
        {
            var result = await _gamemovementservice.AddGameMovement(_gamemovement);
            return Ok(result);
        }

        [HttpPut(nameof(UpdateGameMovement))]
        public async Task<IActionResult> UpdateGameMovement([FromBody] GameMovementVM _gamemovement)
        {
            var result = await _gamemovementservice.UpdateGameMovement(_gamemovement);
            return Ok(result);
        }

        [HttpDelete(nameof(DeleteGameMovement))]
        public async Task<IActionResult> DeleteGameMovement(Guid id)
        {
            var result = await _gamemovementservice.DeleteGameMovement(id);
            return Ok(result);
        }
    }
}
