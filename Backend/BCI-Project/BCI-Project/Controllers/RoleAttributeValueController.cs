using BCI_Project.Services.RoleAttributeValueService;
using BCI_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BCI_Project.Controllers
{
    [AllowAnonymous]
    public class RoleAttributeValueController : Controller
    {
        private readonly IRoleAttributeValueService _roleattributevalueservice;
        public RoleAttributeValueController(IRoleAttributeValueService roleattributevalueservice)
        {
            _roleattributevalueservice = roleattributevalueservice;
        }



        [HttpGet(nameof(GetAllRoleAttributeValues))]
        public async Task<IActionResult> GetAllRoleAttributeValues()
        {
            var result = await _roleattributevalueservice.GetAllRoleAttributeValues();
            return Ok(result);
        }

        [HttpGet(nameof(GetAllRoleAttributeValuesByUserId))]
        public async Task<IActionResult> GetAllRoleAttributeValuesByUserId(string userid)
        {
            var result = await _roleattributevalueservice.GetAllRoleAttributeValuesByUserId(userid);
            return Ok(result);
        }

        [HttpGet(nameof(GetRoleAttributeValueById))]
        public async Task<IActionResult> GetRoleAttributeValueById(Guid id)
        {
            var result = await _roleattributevalueservice.GetRoleAttributeValueById(id);
            return Ok(result);
        }

        [HttpPost(nameof(AddRoleAttributeValue))]
        public async Task<IActionResult> AddRoleAttributeValue([FromBody] RoleAttributeValueVM _roleattributevalue)
        {
            var result = await _roleattributevalueservice.AddRoleAttributeValue(_roleattributevalue);
            return Ok(result);
        }

        [HttpPut(nameof(UpdateRoleAttributeValue))]
        public async Task<IActionResult> UpdateRoleAttributeValue([FromBody] RoleAttributeValueVM _roleattributevalue)
        {
            var result = await _roleattributevalueservice.UpdateRoleAttributeValue(_roleattributevalue);
            return Ok(result);
        }

        [HttpDelete(nameof(DeleteRoleAttributeValue))]
        public async Task<IActionResult> DeleteRoleAttributeValue(Guid id)
        {
            var result = await _roleattributevalueservice.DeleteRoleAttributeValue(id);
            return Ok(result);
        }
    }
}
