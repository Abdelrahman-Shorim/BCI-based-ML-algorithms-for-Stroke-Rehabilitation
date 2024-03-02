using BCI_Project.Models;
using BCI_Project.Response;
using BCI_Project.ViewModels.UserVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BCI_Project.Services.UserService
{
    public class UserService : IUserService
    {
        private UserManager<User> _userManager;
        private IConfiguration _configuration;
        public UserService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<Response<Object>> RegisterUserAsync(RegisterVM user)
        {

            if (user == null)
                return new Response<Object>()
                {
                    Message = "User is Null",
                    IsSuccess = false,
                };
            if (user.Password != user.ConfirmPassword)
                return new Response<Object>()
                {
                    Message = "Passwords Didn't Match",
                    IsSuccess = false,
                };
            var userExist = await _userManager.FindByEmailAsync(user.Email);
            if (userExist != null)
                return new Response<object>()
                {
                    Message = "Email Already Registered",
                    IsSuccess = false
                };

            var identityuser = new User
            {
                Email = user.Email,
                UserName = user.Email,
                EmailConfirmed = true,
                //City = "Cairo"
            };
            var result = await _userManager.CreateAsync(identityuser, user.Password);
            if (result.Succeeded)
            {
                var result2 = await _userManager.AddToRoleAsync(identityuser, "Patient");
                if (result2.Succeeded)
                    return new Response<Object>()
                    {
                        Message = "User Created Succesfully",
                        IsSuccess = true,
                    };
            }
            return new Response<Object>()
            {
                Message = "Error While creating user",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description).ToList()
            };
        }

        public async Task<Response<Object>> LoginUserAsync(LoginVM LoginData)
        {
            var user = await _userManager.FindByEmailAsync(LoginData.Email);
            if (user == null)
            {
                return new Response<object>
                {
                    Message = "There is no user with that Email address",
                    IsSuccess = false,
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, LoginData.Password);

            if (!result)
                return new Response<object>
                {
                    Message = "Invalid password",
                    IsSuccess = false,
                };

            var claims = new List<Claim>
            {
                //new Claim(ClaimTypes.Name, user.UserName),
                 //new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("Email", LoginData.Email),
            };
            /*var userrole= await _userManager.GetRolesAsync(user);
            foreach (var role in userrole)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }*/


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new Response<object>
            {
                Message = tokenAsString,
                IsSuccess = true
                //ExpireDate = token.ValidTo
            };
        }
    }
}
