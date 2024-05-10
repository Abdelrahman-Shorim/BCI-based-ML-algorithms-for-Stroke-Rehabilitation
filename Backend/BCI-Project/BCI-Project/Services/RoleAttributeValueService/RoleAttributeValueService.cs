using BCI_Project.Models;
using BCI_Project.Response;
using BCI_Project.UnitOfWork;
using BCI_Project.ViewModels;

namespace BCI_Project.Services.RoleAttributeValueService
{
    public class RoleAttributeValueService : IRoleAttributeValueService
    {
        private readonly IUnitOfWork _unitofwork;
        public RoleAttributeValueService(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Response<ICollection<RoleAttributeValueVM>>> GetAllRoleAttributeValues()
        {
            var roleattributevalue = _unitofwork.RoleAttributeValue.GetAll().Select(a => new RoleAttributeValueVM()
            {
                Id = a.Id,
                RoleAttributeId = a.RoleAttributeId,
                UserId = a.UserId,
                Value = a.Value
            }).ToList();

            if (roleattributevalue == null || roleattributevalue.Count() <= 0)
            {
                return new Response<ICollection<RoleAttributeValueVM>>()
                {
                    Message = "No RoleAttributeValue Items",
                    IsSuccess = true
                };
            }

            return new Response<ICollection<RoleAttributeValueVM>>()
            {
                Message = "These are the RoleAttributeValue Items",
                IsSuccess = true,
                Data = roleattributevalue
            };
        }
        public async Task<Response<RoleAttributeValueVM>> GetRoleAttributeValueById(Guid id)
        {
            var roleattributevalue = _unitofwork.RoleAttributeValue.GetById(id);
            if (roleattributevalue == null)
                return new Response<RoleAttributeValueVM>()
                {
                    Message = "No RoleAttributeValue Item with this Id",
                    IsSuccess = true
                };
            RoleAttributeValueVM roleattributevalueitem = new RoleAttributeValueVM()
            {
                Id = roleattributevalue.Id,
                RoleAttributeId=roleattributevalue.RoleAttributeId,
                UserId = roleattributevalue.UserId,
                Value = roleattributevalue.Value
            };
            return new Response<RoleAttributeValueVM>()
            {
                Message = "RoleAttributeValue is available",
                IsSuccess = true,
                Data = roleattributevalueitem
            };
        }
        public async Task<Response<RoleAttributeValueVM>> AddRoleAttributeValue(RoleAttributeValueVM roleattributevalue)
        {
            if (roleattributevalue == null)
            {
                return new Response<RoleAttributeValueVM>()
                {
                    Message = "RoleAttributeValue is null",
                    IsSuccess = false
                };
            }
            RoleAttributeValue _roleattributevalue = new RoleAttributeValue()
            {
                RoleAttributeId = roleattributevalue.RoleAttributeId,
                UserId=roleattributevalue.UserId,
                Value=roleattributevalue.Value,
                IsDeleted = false
            };
            var addedroleattributevalue = _unitofwork.RoleAttributeValue.Add(_roleattributevalue);
            if (addedroleattributevalue == null)
                return new Response<RoleAttributeValueVM>()
                {
                    Message = "Can't add RoleAttributeValue",
                    IsSuccess = false
                };
            _unitofwork.Save();
            roleattributevalue.Id = _roleattributevalue.Id;
            return new Response<RoleAttributeValueVM>()
            {
                Message = "RoleAttributeValue Added Succesfully",
                IsSuccess = true,
                Data = roleattributevalue
            };
        }
        public async Task<Response<RoleAttributeValueVM>> UpdateRoleAttributeValue(RoleAttributeValueVM roleattributevalue)
        {
            if (roleattributevalue == null)
            {
                return new Response<RoleAttributeValueVM>()
                {
                    Message = "RoleAttributeValue is null",
                    IsSuccess = false
                };
            }
            var _roleattributevalue = _unitofwork.RoleAttributeValue.GetById(roleattributevalue.Id);
            if (_roleattributevalue == null)
            {
                return new Response<RoleAttributeValueVM>()
                {
                    Message = "No RoleAttributeValue with this id",
                    IsSuccess = false
                };
            }
            _roleattributevalue.RoleAttributeId = roleattributevalue.RoleAttributeId;
            _roleattributevalue.UserId = roleattributevalue.UserId;
            _roleattributevalue.Value = roleattributevalue.Value;

            var updatedroleattributevalue = _unitofwork.RoleAttributeValue.Update(_roleattributevalue);
            if (updatedroleattributevalue == null)
                return new Response<RoleAttributeValueVM>()
                {
                    Message = "Can't Update RoleAttributeValue",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<RoleAttributeValueVM>()
            {
                Message = "RoleAttributeValue Updated Succesfully",
                IsSuccess = true,
                Data = roleattributevalue
            };
        }
        public async Task<Response<RoleAttributeValueVM>> DeleteRoleAttributeValue(Guid id)
        {
            var _roleattributevalue = _unitofwork.RoleAttributeValue.GetById(id);
            if (_roleattributevalue == null)
            {
                return new Response<RoleAttributeValueVM>()
                {
                    Message = "No RoleAttributeValue with this id",
                    IsSuccess = false
                };
            }
            var deletedroleattributevalue = _unitofwork.RoleAttributeValue.Delete(id);
            if (deletedroleattributevalue != null)
                return new Response<RoleAttributeValueVM>()
                {
                    Message = "Can't delete RoleAttributeValue",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<RoleAttributeValueVM>()
            {
                Message = "RoleAttributeValue Deleted Successfully",
                IsSuccess = true
            };
        }
    
        public async Task<Response<ICollection<RoleAttributeValueVM>>> GetAllRoleAttributeValuesByUserId(string userid)
        {
            var roleattributevalue = _unitofwork.RoleAttributeValue.GetAll().Select(a => new RoleAttributeValueVM()
            {
                Id = a.Id,
                RoleAttributeId = a.RoleAttributeId,
                UserId = a.UserId,
                Value = a.Value
            }).Where(a=> a.UserId==userid)
                .ToList();

            if (roleattributevalue == null || roleattributevalue.Count() <= 0)
            {
                return new Response<ICollection<RoleAttributeValueVM>>()
                {
                    Message = "No RoleAttributeValue Items",
                    IsSuccess = true
                };
            }

            return new Response<ICollection<RoleAttributeValueVM>>()
            {
                Message = "These are the RoleAttributeValue Items",
                IsSuccess = true,
                Data = roleattributevalue
            };
        }

    }
}
