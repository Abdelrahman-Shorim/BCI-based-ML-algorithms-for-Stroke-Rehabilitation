using BCI_Project.Models;
using BCI_Project.Response;
using BCI_Project.UnitOfWork;
using BCI_Project.ViewModels;

namespace BCI_Project.Services.AttributeService
{
    public class AttributeService : IAttributeService
    {
        private readonly IUnitOfWork _unitofwork;
        public AttributeService(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Response<ICollection<AttributeVM>>> GetAllAttributes()
        {
            var attributes = _unitofwork.Attributes.GetAll().Select(a => new AttributeVM()
            {
                Id = a.Id,
                AttributeName = a.AttributeName,
                AttributeType = a.AttributeType,
            }).ToList();

            if (attributes == null || attributes.Count() <= 0)
            {
                return new Response<ICollection<AttributeVM>>()
                {
                    Message = "No Attribute Items",
                    IsSuccess = true
                };
            }

            return new Response<ICollection<AttributeVM>>()
            {
                Message = "These are the Attributes Items",
                IsSuccess = true,
                Data = attributes
            };
        }
        public async Task<Response<AttributeVM>> GetAttributeById(Guid id)
        {
            var attribute = _unitofwork.Attributes.GetById(id);
            if (attribute == null)
                return new Response<AttributeVM>()
                {
                    Message = "No Attribute Item with this Id",
                    IsSuccess = true
                };
            AttributeVM attributeitem = new AttributeVM()
            {
                Id = attribute.Id,
                AttributeName = attribute.AttributeName,
                AttributeType = attribute.AttributeType,
            };
            return new Response<AttributeVM>()
            {
                Message = "Attribute is available",
                IsSuccess = true,
                Data = attributeitem
            };
        }
        public async Task<Response<AttributeVM>> GetAttributeByName(string attributename)
        {
            var attributes = _unitofwork.Attributes.GetAll().Select(a => new AttributeVM()
            {
                Id = a.Id,
                AttributeName = a.AttributeName,
                AttributeType = a.AttributeType,
            }).Where(a => a.AttributeName.ToLower() == attributename.ToLower())
                .ToList();

            if (attributes == null || attributes.Count() <= 0)
            {
                return new Response<AttributeVM>()
                {
                    Message = "No Attribute Item with this name",
                    IsSuccess = true
                };
            }

            return new Response<AttributeVM>()
            {
                Message = "Attribute is available",
                IsSuccess = true,
                Data = attributes.First()
            };
        }
        public async Task<Response<AttributeVM>> AddAttribute(AttributeVM attribute)
        {
            if (attribute == null)
            {
                return new Response<AttributeVM>()
                {
                    Message = "Attribute is null",
                    IsSuccess = false
                };
            }
            Attributes _attribute = new Attributes()
            {
                AttributeName = attribute.AttributeName,
                AttributeType = attribute.AttributeType,
                IsDeleted = false
            };
            var addedattribute = _unitofwork.Attributes.Add(_attribute);
            if (addedattribute == null)
                return new Response<AttributeVM>()
                {
                    Message = "Can't add Attribute",
                    IsSuccess = false
                };
            _unitofwork.Save();
            attribute.Id = _attribute.Id;
            return new Response<AttributeVM>()
            {
                Message = "Attribute Added Succesfully",
                IsSuccess = true,
                Data = attribute
            };
        }
        public async Task<Response<AttributeVM>> UpdateAttribute(AttributeVM attribute)
        {
            if (attribute == null)
            {
                return new Response<AttributeVM>()
                {
                    Message = "Attribute is null",
                    IsSuccess = false
                };
            }
            var _attribute = _unitofwork.Attributes.GetById(attribute.Id);
            if (_attribute == null)
            {
                return new Response<AttributeVM>()
                {
                    Message = "No Attribute with this id",
                    IsSuccess = false
                };
            }
            _attribute.AttributeName = attribute.AttributeName;
            _attribute.AttributeType = attribute.AttributeType;


            var updatedattribute = _unitofwork.Attributes.Update(_attribute);
            if (updatedattribute == null)
                return new Response<AttributeVM>()
                {
                    Message = "Can't Update Attribute",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<AttributeVM>()
            {
                Message = "Attribute Updated Succesfully",
                IsSuccess = true,
                Data = attribute
            };
        }
        public async Task<Response<AttributeVM>> DeleteAttribute(Guid id)
        {
            var _attribute = _unitofwork.Attributes.GetById(id);
            if (_attribute == null)
            {
                return new Response<AttributeVM>()
                {
                    Message = "No Attribute with this id",
                    IsSuccess = false
                };
            }
            var deletedattribute = _unitofwork.Attributes.Delete(id);
            if (deletedattribute != null)
                return new Response<AttributeVM>()
                {
                    Message = "Can't delete Attribute",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<AttributeVM>()
            {
                Message = "Attribute Deleted Successfully",
                IsSuccess = true
            };
        }
    }
}
