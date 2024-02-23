using BCI_Project.Models;
using BCI_Project.Response;
using BCI_Project.UnitOfWork;
using BCI_Project.ViewModels;

namespace BCI_Project.Services.GameService
{
    public class GameService: IGameService
    {
        private readonly IUnitOfWork _unitofwork;
        public GameService(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Response<ICollection<GameVM>>> GetAllGames()
        {
            var games= _unitofwork.Game.GetAll().Select(a => new GameVM()
            {
                Id = a.Id,
                PatientId = a.PatientId,
                GameTypeId = a.GameTypeId,
                Score = a.Score,
                Duration = a.Duration,
                Accuracy = a.Accuracy,
                Date = a.Date,
                //Name = a.Name
            }).ToList();

            if (games == null || games.Count()<=0)
            {
                return new Response<ICollection<GameVM>>()
                {
                    Message = "No Game Items",
                    IsSuccess = true
                };
            }

            return new Response<ICollection<GameVM>>()
            {
                Message= "These are the Game Items",
                IsSuccess=true,
                Data=games
            };
        }
        public async Task<Response<GameVM>> GetGameById(Guid id)
        {
            var game= _unitofwork.Game.GetById(id);
            if (game == null)
                return new Response<GameVM>()
                {
                    Message = "No Game Item with this Id",
                    IsSuccess = false
                };
            GameVM gameItem = new GameVM()
            {
                Id = game.Id,
                PatientId= game.PatientId,
                GameTypeId = game.GameTypeId,
                Score = game.Score,
                Duration = game.Duration,
                Accuracy = game.Accuracy,
                Date = game.Date,
            };
            return new Response<GameVM>()
            {
                Message = "Item is available",
                IsSuccess = true,
                Data= gameItem
            };
        }
        public async Task<Response<GameVM>> AddGame(GameVM game,string userid)
        {
            if(game==null)
            {
                return new Response<GameVM>()
                {
                    Message = "Game is null",
                    IsSuccess = false
                };
            }
            Game _game = new Game() 
            {   
                PatientId = userid,
                GameTypeId = game.GameTypeId,
                Score=game.Score,
                Duration=game.Duration,
                Accuracy=game.Accuracy,
                Date=game.Date,
                IsDeleted = false 
            };
            var addedgame = _unitofwork.Game.Add(_game);
            if (addedgame == null)
                return new Response<GameVM>()
                {
                    Message = "Can't add Game",
                    IsSuccess = false
                };
            _unitofwork.Save();
            game.Id= _game.Id;
            return new Response<GameVM>()
            {
                Message = "Game Added Succesfully",
                IsSuccess = true,
                Data=game
            };
        }
        public async Task<Response<GameVM>> UpdateGame(GameVM game)
        {
            if (game == null)
            {
                return new Response<GameVM>()
                {
                    Message = "Game is null",
                    IsSuccess = false
                };
            }
            var _game=_unitofwork.Game.GetById(game.Id);
            if (_game == null)
            {
                return new Response<GameVM>()
                {
                    Message = "No Game with this id",
                    IsSuccess = false
                };
            }
            _game.PatientId = game.PatientId;
            _game.GameTypeId = game.GameTypeId;
            _game.Score = game.Score;
            _game.Duration = game.Duration;
            _game.Accuracy = game.Accuracy;
            _game.Date = game.Date;

            var updatedgame=_unitofwork.Game.Update(_game);
            if(updatedgame == null)
                return new Response<GameVM>()
                {
                    Message = "Can't Update Game",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<GameVM>()
            {
                Message = "Game Updated Succesfully",
                IsSuccess = true,
                Data=game
            };
        }
        public async Task<Response<GameVM>> DeleteGame(Guid id)
        {
            var _game = _unitofwork.Game.GetById(id);
            if (_game == null)
            {
                return new Response<GameVM>()
                {
                    Message = "No Game with this id",
                    IsSuccess = false
                };
            }
            var deletedgame= _unitofwork.Game.Delete(id);
            if (deletedgame != null)
                return new Response<GameVM>()
                {
                    Message = "Can't delete Game",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<GameVM>()
            {
                Message = "Game Deleted Successfully",
                IsSuccess = true
            };
        }
    }
}
