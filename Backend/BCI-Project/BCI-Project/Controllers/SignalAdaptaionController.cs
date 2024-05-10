using BCI_Project.Services.SignalsAdaptaionService;
using BCI_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BCI_Project.Controllers
{
    [AllowAnonymous]
    public class SignalAdaptaionController : Controller
    {
        private readonly ISignalAdaptationService _signalsadaptation;
        public SignalAdaptaionController(ISignalAdaptationService signalsadaptation)
        {
            _signalsadaptation = signalsadaptation;
        }

        [HttpGet(nameof(GetAllSignalsAdaptations))]
        public async Task<IActionResult> GetAllSignalsAdaptations()
        {
            var result = await _signalsadaptation.GetAllSignalsAdaptations();
            return Ok(result);
        }

        [HttpGet(nameof(GetSignalsAdaptationById))]
        public async Task<IActionResult> GetSignalsAdaptationById(Guid id)
        {
            var result = await _signalsadaptation.GetSignalsAdaptationById(id);
            return Ok(result);
        }

        [HttpPost(nameof(AddSignalsAdaptation))]
        public async Task<IActionResult> AddSignalsAdaptation([FromBody] SignalsAdaptationVM signalsadaptation)
        {
            var result = await _signalsadaptation.AddSignalsAdaptation(signalsadaptation);
            return Ok(result);
        }

        [HttpPut(nameof(UpdateSignalsAdaptation))]
        public async Task<IActionResult> UpdateSignalsAdaptation([FromBody] SignalsAdaptationVM signalsadaptation)
        {
            var result = await _signalsadaptation.UpdateSignalsAdaptation(signalsadaptation);
            return Ok(result);
        }

        [HttpDelete(nameof(DeleteSignalsAdaptation))]
        public async Task<IActionResult> DeleteSignalsAdaptation(Guid id)
        {
            var result = await _signalsadaptation.DeleteSignalsAdaptation(id);
            return Ok(result);
        }
    }
}
