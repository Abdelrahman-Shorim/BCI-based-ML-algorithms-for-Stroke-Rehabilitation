using BCI_Project.Models;
using BCI_Project.Response;
using BCI_Project.ViewModels;

namespace BCI_Project.Services.GameService
{
    public interface IGameService
    {
        Task<Response<ICollection<GameVM>>> GetAllGames();
        Task<Response<GameVM>> GetGameById(Guid id);
        Task<Response<GameVM>> AddGame(GameVM game,string userid);
        Task<Response<GameVM>> UpdateGame(GameVM game);
        Task<Response<GameVM>> DeleteGame(Guid id);
    }
}
