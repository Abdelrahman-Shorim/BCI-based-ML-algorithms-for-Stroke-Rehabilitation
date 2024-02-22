using BCI_Project.Models;
using BCI_Project.Response;
using BCI_Project.UnitOfWork;

namespace BCI_Project.Services.GameService
{
    public class GameService: IGameService
    {
        private readonly IUnitOfWork _unitofwork;
        public GameService(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Response<ICollection<Game>>> GetAllGames()
        {
            var games= _unitofwork.Game.GetAll().Select(a => new Game()
            {
                Id = a.Id,
                //Name = a.Name
            }).ToList();

            if (games == null)
            {
                return new Response<ICollection<Game>>()
                {
                    Message = "No Game Items",
                    IsSuccess = true
                };
            }

            return new Response<ICollection<Game>>()
            {
                Message= "These are the Game Items",
                IsSuccess=true,
                Data=games
            };
        }
        public async Task<Response<Game>> GetGameById(Guid id)
        {
            var game= _unitofwork.Game.GetById(id);
            if (game == null)
                return new Response<Game>()
                {
                    Message = "No Game Item with this Id",
                    IsSuccess = false
                };
            Game gameItem = new Game()
            {
                Id = game.Id,
            };
            return new Response<Game>()
            {
                Message = "Item is available",
                IsSuccess = true,
                Data= gameItem
            };
        }
        public async Task<Response<Game>> AddGame(Game game,string userid)
        {
            if(game==null)
            {
                return new Response<Game>()
                {
                    Message = "Game is null",
                    IsSuccess = false
                };
            }
            Game _game = new Game() 
            {   PatientId = userid,
                LevelId=game.LevelId,
                Score=game.Score,
                Duration=game.Duration,
                Accuracy=game.Accuracy,
                Date=DateTime.Now,
                IsDeleted = false 
            };
            var addedgame = _unitofwork.Game.Add(_game);
            if (addedgame == null)
                return new Response<Game>()
                {
                    Message = "Can't add Game",
                    IsSuccess = false
                };
            _unitofwork.Save();
            game.Id= _game.Id;
            return new Response<Game>()
            {
                Message = "Game Added Succesfully",
                IsSuccess = true,
                Data=game
            };
        }
        public async Task<Response<Game>> UpdateGame(Game game)
        {
            if (game == null)
            {
                return new Response<Game>()
                {
                    Message = "Game is null",
                    IsSuccess = false
                };
            }
            var _game=_unitofwork.Game.GetById(game.Id);
            if (_game == null)
            {
                return new Response<Game>()
                {
                    Message = "No Game with this id",
                    IsSuccess = false
                };
            }
            var updatedgame=_unitofwork.Game.Update(_game);
            if(updatedgame == null)
                return new Response<Game>()
                {
                    Message = "Can't Update Game",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<Game>()
            {
                Message = "Game Updated Succesfully",
                IsSuccess = true,
                Data=game
            };
        }
        public async Task<Response<Game>> DeleteGame(Guid id)
        {
            var _game = _unitofwork.Game.GetById(id);
            if (_game == null)
            {
                return new Response<Game>()
                {
                    Message = "No Game with this id",
                    IsSuccess = false
                };
            }
            var deletedgame= _unitofwork.Game.Delete(id);
            if (deletedgame != null)
                return new Response<Game>()
                {
                    Message = "Can't delete Game",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<Game>()
            {
                Message = "Game Deleted Successfully",
                IsSuccess = true
            };
        }
    }
}
