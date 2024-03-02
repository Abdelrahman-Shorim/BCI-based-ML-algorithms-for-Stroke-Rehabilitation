using BCI_Project.Services.UserService;
using BCI_Project.ViewModels.UserVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BCI_Project.Controllers
{
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




        [HttpGet(nameof(Doctorqq))]
        [Authorize]
        public  IActionResult Doctorqq()
        {
            //var result = await _userservice.LoginUserAsync(user);
            return Ok("Hiiiiiiiiiiii");
        }
        [HttpGet(nameof(Patientqq))]
        [AllowAnonymous]
        public IActionResult Patientqq()
        {
            return Ok("Hiiiiiiiiiiii");
        }
    }
}
