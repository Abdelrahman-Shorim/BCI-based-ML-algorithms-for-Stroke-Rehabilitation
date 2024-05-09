using BCI_Project.Response;
using BCI_Project.ViewModels;

namespace BCI_Project.Services.RoleAttributeValueService
{
    public interface IRoleAttributeValueService
    {
        Task<Response<ICollection<RoleAttributeValueVM>>> GetAllRoleAttributeValues();
        Task<Response<RoleAttributeValueVM>> GetRoleAttributeValueById(Guid id);
        Task<Response<RoleAttributeValueVM>> AddRoleAttributeValue(RoleAttributeValueVM roleattributevalue);
        Task<Response<RoleAttributeValueVM>> UpdateRoleAttributeValue(RoleAttributeValueVM roleattributevalue);
        Task<Response<RoleAttributeValueVM>> DeleteRoleAttributeValue(Guid id);
    }
}
