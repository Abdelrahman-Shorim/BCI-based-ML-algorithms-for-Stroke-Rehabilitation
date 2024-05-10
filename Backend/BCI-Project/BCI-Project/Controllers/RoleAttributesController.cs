using BCI_Project.Services.RoleAttributesService;
using BCI_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BCI_Project.Controllers
{
    [AllowAnonymous]
    public class RoleAttributesController : Controller
    {
        private readonly IRoleAttributeService _rolattributeservice;
        public RoleAttributesController(IRoleAttributeService rolattributeservice)
        {
            _rolattributeservice = rolattributeservice;
        }


        [HttpGet(nameof(GetAllRoleAttributes))]
        public async Task<IActionResult> GetAllRoleAttributes()
        {
            var result = await _rolattributeservice.GetAllRoleAttributes();
            return Ok(result);
        }

        [HttpGet(nameof(GetRoleAttributeByRoleAndAttributeId))]
        public async Task<IActionResult> GetRoleAttributeByRoleAndAttributeId(string roleid, Guid attributeid)
        {
            var result = await _rolattributeservice.GetRoleAttributeByRoleAndAttributeId(roleid, attributeid);
            return Ok(result);
        }

        [HttpGet(nameof(GetRoleAttributesById))]
        public async Task<IActionResult> GetRoleAttributesById(Guid id)
        {
            var result = await _rolattributeservice.GetRoleAttributesById(id);
            return Ok(result);
        }

        [HttpPost(nameof(AddRoleAttributes))]
        public async Task<IActionResult> AddRoleAttributes([FromBody] RoleAttributesVM _rolattribute)
        {
            var result = await _rolattributeservice.AddRoleAttributes(_rolattribute);
            return Ok(result);
        }

        [HttpPut(nameof(UpdateRoleAttributes))]
        public async Task<IActionResult> UpdateRoleAttributes([FromBody] RoleAttributesVM _rolattribute)
        {
            var result = await _rolattributeservice.UpdateRoleAttributes(_rolattribute);
            return Ok(result);
        }

        [HttpDelete(nameof(DeleteRoleAttributes))]
        public async Task<IActionResult> DeleteRoleAttributes(Guid id)
        {
            var result = await _rolattributeservice.DeleteRoleAttributes(id);
            return Ok(result);
        }
    }
}
