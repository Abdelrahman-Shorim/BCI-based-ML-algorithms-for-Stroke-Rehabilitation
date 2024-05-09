using BCI_Project.Services.AttributeService;
using BCI_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BCI_Project.Controllers
{
    public class AttributeController : Controller
    {
        private readonly IAttributeService _attributeservice;
        public AttributeController(IAttributeService attributeservice)
        {
            _attributeservice = attributeservice;
        }

        [HttpGet(nameof(GetAllAttributes))]
        public async Task<IActionResult> GetAllAttributes()
        {
            var result = await _attributeservice.GetAllAttributes();
            return Ok(result);
        }

        [HttpGet(nameof(GetAttributeByName))]
        public async Task<IActionResult> GetAttributeByName(string name)
        {
            var result = await _attributeservice.GetAttributeByName(name);
            return Ok(result);
        }

        [HttpGet(nameof(GetAttributeById))]
        public async Task<IActionResult> GetAttributeById(Guid id)
        {
            var result = await _attributeservice.GetAttributeById(id);
            return Ok(result);
        }

        [HttpPost(nameof(AddAttribute))]
        public async Task<IActionResult> AddAttribute([FromBody] AttributeVM _attribute)
        {
            var result = await _attributeservice.AddAttribute(_attribute);
            return Ok(result);
        }

        [HttpPut(nameof(UpdateAttribute))]
        public async Task<IActionResult> UpdateAttribute([FromBody] AttributeVM _attribute)
        {
            var result = await _attributeservice.UpdateAttribute(_attribute);
            return Ok(result);
        }

        [HttpDelete(nameof(DeleteAttribute))]
        public async Task<IActionResult> DeleteAttribute(Guid id)
        {
            var result = await _attributeservice.DeleteAttribute(id);
            return Ok(result);
        }
    }
}
