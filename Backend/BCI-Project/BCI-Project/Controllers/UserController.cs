using BCI_Project.Models;
using BCI_Project.Services.UserService;
using BCI_Project.ViewModels.UserVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BCI_Project.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IUserService _userservice;
        public UserController(IUserService userservice)
        {
            _userservice = userservice;
        }

        [HttpPost(nameof(RegisterAsync))]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterVM user)
        {
            var result = await _userservice.RegisterUserAsync(user);
            return Ok(result);
        }

        [HttpPost(nameof(LoginAsync))]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginVM user)
        {
            var result = await _userservice.LoginUserAsync(user);
            return Ok(result);
        }

        [HttpPost(nameof(GetTreatmentProgressByPatientId))]
        [AllowAnonymous]
        public async Task<IActionResult> GetTreatmentProgressByPatientId(string patientid)
        {
            var result = await _userservice.GetTreatmentProgressByPatientId(patientid);
            return Ok(result);
        }

        [HttpPost(nameof(AddTargetToPatient))]
        [AllowAnonymous]
        public async Task<IActionResult> AddTargetToPatient(string patientid, int target)
        {
            var result = await _userservice.AddTargetToPatient(patientid, target);
            return Ok(result);
        }


      
        [HttpGet(nameof(GetDoctorPatients))]
        [AllowAnonymous]
        public async Task<IActionResult> GetDoctorPatients(string doctorid)
        {
            var result = await _userservice.GetDoctorPatients(doctorid);
            return Ok(result);
        }

        [HttpGet(nameof(GetAllDoctors))]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllDoctors()
        {
            var result = await _userservice.GetAllDoctors();
            return Ok(result);
        }

        [HttpGet(nameof(GetAllPatients))]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPatients()
        {
            var result = await _userservice.GetAllPatients();
            return Ok(result);
        }
        [HttpGet(nameof(GetUnAssignedPatients))]
        [AllowAnonymous]
        public async Task<IActionResult> GetUnAssignedPatients()
        {
            var result = await _userservice.GetUnAssignedPatients();
            return Ok(result);
        }

        [HttpGet(nameof(GetDoctorOrAdminProfile))]
        [AllowAnonymous]
        public async Task<IActionResult> GetDoctorOrAdminProfile(string uid)
        {
            var result = await _userservice.GetDoctorOrAdminProfile(uid);
            return Ok(result);
        }


        [HttpGet(nameof(GetPatientDetails))]
        [AllowAnonymous]
        public async Task<IActionResult> GetPatientDetails(string patientid)
        {
            var result = await _userservice.GetPatientDetails( patientid);
            return Ok(result);
        }
        [HttpPost(nameof(AddDoctor))]
        [AllowAnonymous]
        public async Task<IActionResult> AddDoctor([FromBody] RegisterDoctor user)
        {
            var result = await _userservice.AddDoctor(user);
            return Ok(result);
        }
        [HttpPost(nameof(AddAdmin))]
        [AllowAnonymous]
        public async Task<IActionResult> AddAdmin([FromBody] RegisterDoctor user)
        {
            var result = await _userservice.AddAdmin(user);
            return Ok(result);
        }

        //[HttpPost(nameof(AddAttribute))]
        //[AllowAnonymous]
        //public async Task<IActionResult> AddAttribute([FromBody] AttributeVM attribute)
        //{
        //    var result = await _userservice.AddAttribute(attribute);
        //    return Ok(result);
        //}




        //[HttpGet(nameof(Doctorqq))]
        //[Authorize]
        //public  IActionResult Doctorqq()
        //{
        //    //var result = await _userservice.LoginUserAsync(user);
        //    return Ok("Hiiiiiiiiiiii");
        //}
        //[HttpGet(nameof(Patientqq))]
        //[AllowAnonymous]
        //public IActionResult Patientqq()
        //{
        //    return Ok("Hiiiiiiiiiiii");
        //}
    }
}
