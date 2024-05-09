using BCI_Project.Models;
using BCI_Project.Response;
using BCI_Project.UnitOfWork;
using BCI_Project.ViewModels;

namespace BCI_Project.Services.RoleAttributesService
{
    public class RoleAttributeService : IRoleAttributeService
    {
        private readonly IUnitOfWork _unitofwork;
        public RoleAttributeService(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Response<ICollection<RoleAttributesVM>>> GetAllRoleAttributes()
        {
            var roleattribute = _unitofwork.RoleAttributes.GetAll().Select(a => new RoleAttributesVM()
            {
                Id = a.Id,
                RoleId = a.RoleId,
                AttributeId = a.AttributeId,
            }).ToList();

            if (roleattribute == null || roleattribute.Count() <= 0)
            {
                return new Response<ICollection<RoleAttributesVM>>()
                {
                    Message = "No RoleAttributes Items",
                    IsSuccess = true
                };
            }

            return new Response<ICollection<RoleAttributesVM>>()
            {
                Message = "These are the RoleAttributes Items",
                IsSuccess = true,
                Data = roleattribute
            };
        }

        public async Task<Response<RoleAttributesVM>> GetRoleAttributeByRoleAndAttributeId(string roleid, Guid attributeid)
        {
            var roleattribute = _unitofwork.RoleAttributes.GetAll().Select(a => new RoleAttributesVM()
            {
                Id = a.Id,
                RoleId = a.RoleId,
                AttributeId = a.AttributeId,
            }).Where(a=> a.RoleId==roleid && a.AttributeId==attributeid)
                .ToList();

            if (roleattribute == null || roleattribute.Count() <= 0)
            {
                return new Response<RoleAttributesVM>()
                {
                    Message = "No RoleAttributes Items",
                    IsSuccess = true
                };
            }

            return new Response<RoleAttributesVM>()
            {
                Message = "These are the RoleAttributes Items",
                IsSuccess = true,
                Data = roleattribute.First()
            };
        }
        public async Task<Response<RoleAttributesVM>> GetRoleAttributesById(Guid id)
        {
            var roleattribute = _unitofwork.RoleAttributes.GetById(id);
            if (roleattribute == null)
                return new Response<RoleAttributesVM>()
                {
                    Message = "No RoleAttributes Item with this Id",
                    IsSuccess = true
                };
            RoleAttributesVM roleattributeitem = new RoleAttributesVM()
            {
                Id = roleattribute.Id,
                RoleId=roleattribute.RoleId,
                AttributeId = roleattribute.AttributeId,
            };
            return new Response<RoleAttributesVM>()
            {
                Message = "RoleAttributes is available",
                IsSuccess = true,
                Data = roleattributeitem
            };
        }
        public async Task<Response<RoleAttributesVM>> AddRoleAttributes(RoleAttributesVM roleattribute)
        {
            if (roleattribute == null)
            {
                return new Response<RoleAttributesVM>()
                {
                    Message = "RoleAttributes is null",
                    IsSuccess = false
                };
            }
            RoleAttributes _roleattribute = new RoleAttributes()
            {
                RoleId = roleattribute.RoleId,
                AttributeId=roleattribute.AttributeId,
                IsDeleted = false
            };
            var addedroleattribute = _unitofwork.RoleAttributes.Add(_roleattribute);
            if (addedroleattribute == null)
                return new Response<RoleAttributesVM>()
                {
                    Message = "Can't add RoleAttributes",
                    IsSuccess = false
                };
            _unitofwork.Save();
            roleattribute.Id = _roleattribute.Id;
            return new Response<RoleAttributesVM>()
            {
                Message = "RoleAttributes Added Succesfully",
                IsSuccess = true,
                Data = roleattribute
            };
        }
        public async Task<Response<RoleAttributesVM>> UpdateRoleAttributes(RoleAttributesVM roleattribute)
        {
            if (roleattribute == null)
            {
                return new Response<RoleAttributesVM>()
                {
                    Message = "RoleAttributes is null",
                    IsSuccess = false
                };
            }
            var _roleattribute = _unitofwork.RoleAttributes.GetById(roleattribute.Id);
            if (_roleattribute == null)
            {
                return new Response<RoleAttributesVM>()
                {
                    Message = "No RoleAttributes with this id",
                    IsSuccess = false
                };
            }
            _roleattribute.RoleId = roleattribute.RoleId;
            _roleattribute.AttributeId = roleattribute.AttributeId;
            

            var updatedroleattribute = _unitofwork.RoleAttributes.Update(_roleattribute);
            if (updatedroleattribute == null)
                return new Response<RoleAttributesVM>()
                {
                    Message = "Can't Update RoleAttributes",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<RoleAttributesVM>()
            {
                Message = "RoleAttributes Updated Succesfully",
                IsSuccess = true,
                Data = roleattribute
            };
        }
        public async Task<Response<RoleAttributesVM>> DeleteRoleAttributes(Guid id)
        {
            var _roleattribute = _unitofwork.RoleAttributes.GetById(id);
            if (_roleattribute == null)
            {
                return new Response<RoleAttributesVM>()
                {
                    Message = "No RoleAttributes with this id",
                    IsSuccess = false
                };
            }
            var deletedroleattribute = _unitofwork.RoleAttributes.Delete(id);
            if (deletedroleattribute != null)
                return new Response<RoleAttributesVM>()
                {
                    Message = "Can't delete RoleAttributes",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<RoleAttributesVM>()
            {
                Message = "RoleAttributes Deleted Successfully",
                IsSuccess = true
            };
        }
    }
}
