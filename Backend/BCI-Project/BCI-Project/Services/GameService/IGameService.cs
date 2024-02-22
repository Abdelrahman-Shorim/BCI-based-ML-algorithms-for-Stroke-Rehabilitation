using BCI_Project.Models;
using BCI_Project.Response;

namespace BCI_Project.Services.GameService
{
    public interface IGameService
    {
        Task<Response<ICollection<Game>>> GetAllGames();
        Task<Response<Game>> GetGameById(Guid id);
        Task<Response<Game>> AddGame(Game game,string userid);
        Task<Response<Game>> UpdateGame(Game game);
        Task<Response<Game>> DeleteGame(Guid id);
    }
}
