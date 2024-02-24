using BCI_Project.Response;
using BCI_Project.ViewModels;

namespace BCI_Project.Services.GameMovementService
{
    public interface IGameMovementService
    {
        Task<Response<ICollection<GameMovementVM>>> GetAllGameMovements();
        Task<Response<GameMovementVM>> GetGameMovementById(Guid id);
        Task<Response<GameMovementVM>> AddGameMovement(GameMovementVM gamemovement);
        Task<Response<GameMovementVM>> UpdateGameMovement(GameMovementVM gamemovement);
        Task<Response<GameMovementVM>> DeleteGameMovement(Guid id);

        Task<Response<ICollection<GameMovementVM>>> GetAllGameMovementsByGameId(Guid id);

    }
}

