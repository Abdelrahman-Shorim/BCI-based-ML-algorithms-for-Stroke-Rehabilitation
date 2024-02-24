using BCI_Project.Services.DrPatientsService;
using BCI_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BCI_Project.Controllers
{
    public class DrPatientsController : Controller
    {
        private readonly IDrPatientsService _drpatientsservice;
        public DrPatientsController(IDrPatientsService drpatientsservice)
        {
            _drpatientsservice = drpatientsservice;
        }

        [HttpGet(nameof(GetAllDrPatients))]
        public async Task<IActionResult> GetAllDrPatients()
        {
            var result = await _drpatientsservice.GetAllDrPatients();
            return Ok(result);
        }

        [HttpGet(nameof(GetAllDrPatientsByDoctorId))]
        public async Task<IActionResult> GetAllDrPatientsByDoctorId(Guid id)
        {
            var result = await _drpatientsservice.GetAllDrPatientsByDoctorId(id);
            return Ok(result);
        }

        [HttpGet(nameof(GetDrPatientsById))]
        public async Task<IActionResult> GetDrPatientsById(Guid id)
        {
            var result = await _drpatientsservice.GetDrPatientsById(id);
            return Ok(result);
        }

        [HttpPost(nameof(AddDrPatients))]
        public async Task<IActionResult> AddDrPatients([FromBody] DrPatientsVM _drpatients)
        {
            var result = await _drpatientsservice.AddDrPatients(_drpatients);
            return Ok(result);
        }

        [HttpPut(nameof(UpdateDrPatients))]
        public async Task<IActionResult> UpdateDrPatients([FromBody] DrPatientsVM _drpatients)
        {
            var result = await _drpatientsservice.UpdateDrPatients(_drpatients);
            return Ok(result);
        }

        [HttpDelete(nameof(DeleteDrPatients))]
        public async Task<IActionResult> DeleteDrPatients(Guid id)
        {
            var result = await _drpatientsservice.DeleteDrPatients(id);
            return Ok(result);
        }
    }
}
