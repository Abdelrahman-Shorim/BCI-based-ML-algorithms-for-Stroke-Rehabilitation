using BCI_Project.Models;
using BCI_Project.Response;
using BCI_Project.ViewModels;

namespace BCI_Project.Services.RoleAttributesService
{
    public interface IRoleAttributeService
    {
        Task<Response<ICollection<RoleAttributesVM>>> GetAllRoleAttributes();
        Task<Response<RoleAttributesVM>> GetRoleAttributesById(Guid id);
        Task<Response<RoleAttributesVM>> GetRoleAttributeByRoleAndAttributeId(string roleid, Guid attributeid);
        Task<Response<RoleAttributesVM>> AddRoleAttributes(RoleAttributesVM roleattribute);
        Task<Response<RoleAttributesVM>> UpdateRoleAttributes(RoleAttributesVM roleattribute);
        Task<Response<RoleAttributesVM>> DeleteRoleAttributes(Guid id);
    }
}
