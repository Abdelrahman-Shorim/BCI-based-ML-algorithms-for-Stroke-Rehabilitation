using BCI_Project.Models;
using BCI_Project.Response;
using BCI_Project.UnitOfWork;
using BCI_Project.ViewModels;

namespace BCI_Project.Services.GameTypeService
{
    public class GameTypeService : IGameTypeService
    {
        private readonly IUnitOfWork _unitofwork;
        public GameTypeService(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Response<ICollection<GameTypeVM>>> GetAllGameTypes()
        {
            var gametypes = _unitofwork.GameType.GetAll().Select(a => new GameTypeVM()
            {
                Id = a.Id,
                GameTypeName = a.GameTypeName,
                Description = a.Description
                //Name = a.Name
            }).ToList();

            if (gametypes == null || gametypes.Count()<=0)
            {
                return new Response<ICollection<GameTypeVM>> ()
                {
                    Message = "No GameType Items",
                    IsSuccess = true
                };
            }

            return new Response<ICollection<GameTypeVM>>()
            {
                Message = "These are the GameType Items",
                IsSuccess = true,
                Data = gametypes
            };
        }
        public async Task<Response<GameTypeVM>> GetGameTypeById(Guid id)
        {
            var gametype = _unitofwork.GameType.GetById(id);
            if (gametype == null)
                return new Response<GameTypeVM>()
                {
                    Message = "No GameType Item with this Id",
                    IsSuccess = true
                };
            GameTypeVM gametypeitem = new GameTypeVM()
            {
                Id = gametype.Id,
                GameTypeName = gametype.GameTypeName,
                Description = gametype.Description
            };
            return new Response<GameTypeVM>()
            {
                Message = "GameType is available",
                IsSuccess = true,
                Data = gametypeitem
            };
        }
        public async Task<Response<GameTypeVM>> AddGameType(GameTypeVM gametype)
        {
            if (gametype == null)
            {
                return new Response<GameTypeVM>()
                {
                    Message = "GameType is null",
                    IsSuccess = false
                };
            }
            GameType _gametype = new GameType() 
            { 
                GameTypeName = gametype.GameTypeName,
                Description =gametype.Description,
                IsDeleted = false 
            };
            var addedgametype = _unitofwork.GameType.Add(_gametype);
            if (addedgametype == null)
                return new Response<GameTypeVM>()
                {
                    Message = "Can't add GameType",
                    IsSuccess = false
                };
            _unitofwork.Save();
            gametype.Id = _gametype.Id;
            return new Response<GameTypeVM>()
            {
                Message = "GameType Added Succesfully",
                IsSuccess = true,
                Data = gametype
            };
        }
        public async Task<Response<GameTypeVM>> UpdateGameType(GameTypeVM gametype)
        {
            if (gametype == null)
            {
                return new Response<GameTypeVM>()
                {
                    Message = "GameType is null",
                    IsSuccess = false
                };
            }
            var _gametype = _unitofwork.GameType.GetById(gametype.Id);
            if (_gametype == null)
            {
                return new Response<GameTypeVM>()
                {
                    Message = "No GameType with this id",
                    IsSuccess = false
                };
            }
            _gametype.GameTypeName = gametype.GameTypeName;
            _gametype.Description = gametype.Description;

            var updatedgametype = _unitofwork.GameType.Update(_gametype);
            if (updatedgametype == null)
                return new Response<GameTypeVM>()
                {
                    Message = "Can't Update GameType",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<GameTypeVM>()
            {
                Message = "GameType Updated Succesfully",
                IsSuccess = true,
                Data = gametype
            };
        }
        public async Task<Response<GameTypeVM>> DeleteGameType(Guid id)
        {
            var _gametype = _unitofwork.GameType.GetById(id);
            if (_gametype == null)
            {
                return new Response<GameTypeVM>()
                {
                    Message = "No GameType with this id",
                    IsSuccess = false
                };
            }
            var deletedgametype = _unitofwork.GameType.Delete(id);
            if (deletedgametype != null)
                return new Response<GameTypeVM>()
                {
                    Message = "Can't delete GameType",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<GameTypeVM>()
            {
                Message = "GameType Deleted Successfully",
                IsSuccess = true
            };
        }
    }
}
