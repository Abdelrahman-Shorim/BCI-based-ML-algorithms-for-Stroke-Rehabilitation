using BCI_Project.Models;
using BCI_Project.Response;
using BCI_Project.UnitOfWork;
using BCI_Project.ViewModels;

namespace BCI_Project.Services.GameMovementService
{
    public class GameMovementService : IGameMovementService
    {
        private readonly IUnitOfWork _unitofwork;
        public GameMovementService(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }


        public async Task<Response<ICollection<GameMovementVM>>> GetAllGameMovements()
        {
            var gamemovements = _unitofwork.GameMovement.GetAll().Select(a => new GameMovementVM()
            {
                Id = a.Id,
                GameId = a.GameId,
                RequiredMovement = a.RequiredMovement,
                ActualMovement = a.ActualMovement,
                BrainSignals = a.BrainSignals,
            }).ToList();

            if (gamemovements == null || gamemovements.Count() <= 0)
            {
                return new Response<ICollection<GameMovementVM>>()
                {
                    Message = "No GameMovement Items",
                    IsSuccess = true
                };
            }

            return new Response<ICollection<GameMovementVM>>()
            {
                Message = "These are the GameMovement Items",
                IsSuccess = true,
                Data = gamemovements
            };
        }
        public async Task<Response<GameMovementVM>> GetGameMovementById(Guid id)
        {
            var gamemovement = _unitofwork.GameMovement.GetById(id);
            if (gamemovement == null)
                return new Response<GameMovementVM>()
                {
                    Message = "No GameMovement Item with this Id",
                    IsSuccess = true
                };
            GameMovementVM gamemovementitem = new GameMovementVM()
            {
                Id = gamemovement.Id,
                GameId=gamemovement.GameId,
                RequiredMovement = gamemovement.RequiredMovement,
                ActualMovement = gamemovement.ActualMovement,
                BrainSignals=gamemovement.BrainSignals,
            };
            return new Response<GameMovementVM>()
            {
                Message = "GameMovement is available",
                IsSuccess = true,
                Data = gamemovementitem
            };
        }
        public async Task<Response<GameMovementVM>> AddGameMovement(GameMovementVM gamemovement)
        {
            if (gamemovement == null)
            {
                return new Response<GameMovementVM>()
                {
                    Message = "GameMovement is null",
                    IsSuccess = false
                };
            }
            GameMovements _gamemovement = new GameMovements()
            {
                GameId = gamemovement.GameId,
                RequiredMovement=gamemovement.RequiredMovement,
                ActualMovement=gamemovement.ActualMovement,
                BrainSignals = gamemovement.BrainSignals,
                IsDeleted = false
            };
            var addedgamemovement = _unitofwork.GameMovement.Add(_gamemovement);
            if (addedgamemovement == null)
                return new Response<GameMovementVM>()
                {
                    Message = "Can't add GameMovement",
                    IsSuccess = false
                };
            _unitofwork.Save();
            gamemovement.Id = _gamemovement.Id;
            return new Response<GameMovementVM>()
            {
                Message = "GameMovement Added Succesfully",
                IsSuccess = true,
                Data = gamemovement
            };
        }
        public async Task<Response<GameMovementVM>> UpdateGameMovement(GameMovementVM gamemovement)
        {
            if (gamemovement == null)
            {
                return new Response<GameMovementVM>()
                {
                    Message = "GameMovement is null",
                    IsSuccess = false
                };
            }
            var _gamemovement = _unitofwork.GameMovement.GetById(gamemovement.Id);
            if (_gamemovement == null)
            {
                return new Response<GameMovementVM>()
                {
                    Message = "No GameMovement with this id",
                    IsSuccess = false
                };
            }
            _gamemovement.GameId = gamemovement.GameId;
            _gamemovement.RequiredMovement = gamemovement.RequiredMovement;
            _gamemovement.ActualMovement = gamemovement.ActualMovement;
            _gamemovement.BrainSignals = gamemovement.BrainSignals;

            var updatedgamemovement = _unitofwork.GameMovement.Update(_gamemovement);
            if (updatedgamemovement == null)
                return new Response<GameMovementVM>()
                {
                    Message = "Can't Update GameMovement",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<GameMovementVM>()
            {
                Message = "GameMovement Updated Succesfully",
                IsSuccess = true,
                Data = gamemovement
            };
        }
        public async Task<Response<GameMovementVM>> DeleteGameMovement(Guid id)
        {
            var _gamemovement = _unitofwork.GameMovement.GetById(id);
            if (_gamemovement == null)
            {
                return new Response<GameMovementVM>()
                {
                    Message = "No GamemMvement with this id",
                    IsSuccess = false
                };
            }
            var deletedgamemovement = _unitofwork.GameMovement.Delete(id);
            if (deletedgamemovement != null)
                return new Response<GameMovementVM>()
                {
                    Message = "Can't delete GameMovement",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<GameMovementVM>()
            {
                Message = "GameMovement Deleted Successfully",
                IsSuccess = true
            };
        }
        public async Task<Response<ICollection<GameMovementVM>>> GetAllGameMovementsByGameId(Guid id)
        {
            var gamemovements = _unitofwork.GameMovement.GetAll().Select(a => new GameMovementVM()
            {
                Id = a.Id,
                GameId = a.GameId,
                RequiredMovement = a.RequiredMovement,
                ActualMovement = a.ActualMovement,
                BrainSignals = a.BrainSignals,
            }).Where(b=>b.GameId==id).ToList();

            if (gamemovements == null || gamemovements.Count() <= 0)
            {
                return new Response<ICollection<GameMovementVM>>()
                {
                    Message = "No GameMovement Items for this game Id",
                    IsSuccess = true
                };
            }

            return new Response<ICollection<GameMovementVM>>()
            {
                Message = "These are the GameMovement Items for this game Id",
                IsSuccess = true,
                Data = gamemovements
            };
        }

    }
}
