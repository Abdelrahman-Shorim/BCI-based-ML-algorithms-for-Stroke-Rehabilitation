using BCI_Project.Response;
using BCI_Project.ViewModels;

namespace BCI_Project.Services.AttributeService
{
    public interface IAttributeService
    {
                                
        Task<Response<ICollection<AttributeVM>>> GetAllAttributes();
        Task<Response<AttributeVM>> GetAttributeById(Guid id);
        Task<Response<AttributeVM>> GetAttributeByName(string attributename);
        Task<Response<AttributeVM>> AddAttribute(AttributeVM attribute);
        Task<Response<AttributeVM>> UpdateAttribute(AttributeVM attribute);
        Task<Response<AttributeVM>> DeleteAttribute(Guid id);
    }
}
