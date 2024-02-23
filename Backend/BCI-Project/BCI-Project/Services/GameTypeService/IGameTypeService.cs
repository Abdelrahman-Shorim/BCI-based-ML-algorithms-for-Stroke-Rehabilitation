using BCI_Project.Models;
using BCI_Project.Response;
using BCI_Project.ViewModels;

namespace BCI_Project.Services.GameTypeService
{
    public interface IGameTypeService
    {
        Task<Response<ICollection<GameTypeVM>>> GetAllGameTypes();
        Task<Response<GameTypeVM>> GetGameTypeById(Guid id);
        Task<Response<GameTypeVM>> AddGameType(GameTypeVM gametype);
        Task<Response<GameTypeVM>> UpdateGameType(GameTypeVM gametype);
        Task<Response<GameTypeVM>> DeleteGameType(Guid id);
    }
}
