using BCI_Project.Models;
using BCI_Project.Response;
using BCI_Project.Services.AttributeService;
using BCI_Project.Services.DrPatientsService;
using BCI_Project.Services.GameMovementService;
using BCI_Project.Services.GameService;
using BCI_Project.Services.RoleAttributesService;
using BCI_Project.Services.RoleAttributeValueService;
using BCI_Project.UnitOfWork;
using BCI_Project.ViewModels;
using BCI_Project.ViewModels.UserVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
//using BCI_Project.Models;

namespace BCI_Project.Services.UserService
{
    public class UserService : IUserService
    {
        private UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private IConfiguration _configuration;
        private readonly IUnitOfWork _unitofwork;
        private readonly IAttributeService _attributeservice;
        private readonly IRoleAttributeService _roleattributeservice;
        private readonly IRoleAttributeValueService _roleattributevalueservice;
        private readonly IGameService _gameservice;
        private readonly IGameMovementService _gamemovementservice;
        private readonly IDrPatientsService _drpatientsservice;

        public UserService
            (
            UserManager<User> userManager, IConfiguration configuration,
            IUnitOfWork unitofwork, RoleManager<Role> roleManager,
            IAttributeService attributeservice,
            IRoleAttributeService roleattributeservice,
            IRoleAttributeValueService roleattributevalueservice,
            IGameService gameservice,
            IGameMovementService gamemovementservice,
            IDrPatientsService drpatientsservice
            )
        {
            _userManager = userManager;
            _configuration = configuration;
            _unitofwork = unitofwork;
            _roleManager = roleManager;
            _attributeservice = attributeservice;
            _roleattributeservice = roleattributeservice;
            _roleattributevalueservice = roleattributevalueservice;
            _gameservice = gameservice;
            _gamemovementservice = gamemovementservice;
            _drpatientsservice = drpatientsservice;
        }


        public async Task<Response<Object>> AddDoctor(RegisterVM user)
        {
            if (user == null)
                return new Response<Object>()
                {
                    Message = "User is Null",
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
                UserName = user.Name,
                //EmailConfirmed = true,
                PhoneNumber = user.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(identityuser, user.Password);
            if (result.Succeeded)
            {
                var result2 = await _userManager.AddToRoleAsync(identityuser, "Admin");
                if (result2.Succeeded)
                {
                   
                    return new Response<Object>()
                    {
                        Message = "User Created Succesfully",
                        IsSuccess = true,
                    };
                }
            }
            return new Response<Object>()
            {
                Message = "Error While creating user",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description).ToList()
            };
        }
        public async Task<Response<Object>> RegisterUserAsync(RegisterVM user)
        {

            if (user == null)
                return new Response<Object>()
                {
                    Message = "User is Null",
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
                UserName = user.Name,
                //EmailConfirmed = true,
                PhoneNumber = user.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(identityuser, user.Password);
            if (result.Succeeded)
            {
                var result2 = await _userManager.AddToRoleAsync(identityuser, "Patient");
                if (result2.Succeeded)
                {
                    Console.WriteLine("hehehehehhehheheheh");
                    //Console.WriteLine(_roleManager.RoleExistsAsync("Patient"));
                    var role = await _roleManager.FindByNameAsync("Patient");
                    //var role = await _userManager.GetRolesAsync(identityuser);

                    //Console.WriteLine(role.Id);
                    var attributeage = await _attributeservice.GetAttributeByName("Age");
                    var attributeGender = await _attributeservice.GetAttributeByName("Gender");
                    var attributePatientHistory = await _attributeservice.GetAttributeByName("PatientHistory");

                    Console.WriteLine(attributeage);
                    var roleattributeage = await _roleattributeservice.GetRoleAttributeByRoleAndAttributeId(role.Id, attributeage.Data.Id);
                    var roleattributegender = await _roleattributeservice.GetRoleAttributeByRoleAndAttributeId(role.Id, attributeGender.Data.Id);
                    var roleattributepatientHistory = await _roleattributeservice.GetRoleAttributeByRoleAndAttributeId(role.Id, attributePatientHistory.Data.Id);
                    //_userManager.get


                     await _roleattributevalueservice.AddRoleAttributeValue(new RoleAttributeValueVM()
                    {
                        RoleAttributeId = roleattributeage.Data.Id,
                        UserId = identityuser.Id,
                        Value = user.Age.ToString(),
                    });

                    await _roleattributevalueservice.AddRoleAttributeValue(new RoleAttributeValueVM()
                    {
                        RoleAttributeId = roleattributegender.Data.Id,
                        UserId = identityuser.Id,
                        Value = user.Gender,
                    });

                    await _roleattributevalueservice.AddRoleAttributeValue(new RoleAttributeValueVM()
                    {
                        RoleAttributeId = roleattributepatientHistory.Data.Id,
                        UserId = identityuser.Id,
                        Value = user.PatientHistory,
                    });


                    Console.WriteLine(roleattributeage);
                    return new Response<Object>()
                    {
                        Message = "User Created Succesfully",
                        IsSuccess = true,
                    };
                }
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

        public async Task<Response<Object>> AddTargetToPatient(string patientid, int target)
        {
            var role = await _roleManager.FindByNameAsync("Patient");

            var attributetarget = await _attributeservice.GetAttributeByName("Target");

            var roleattributetarget = await _roleattributeservice.GetRoleAttributeByRoleAndAttributeId(role.Id, attributetarget.Data.Id);

            var result =await _roleattributevalueservice.AddRoleAttributeValue(new RoleAttributeValueVM()
            {
                RoleAttributeId = roleattributetarget.Data.Id,
                UserId = patientid,
                Value = target.ToString(),
            });
            if(result!=null)
            {
                return new Response<Object>()
                {
                    Message = "Added Target Succesfully",
                    IsSuccess = true,
                };
            }
            return new Response<Object>()
            {
                Message = "Error While Adding Target",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e).ToList()
            };
        }

        public async Task<Response<List<int[]>>> GetTreatmentProgressByPatientId(string patientid)
        {
            var patient = await _userManager.FindByIdAsync(patientid);
            if(patient==null)
                return new Response<List<int[]>>
                {
                    Message = "There is no patient with this id",
                    IsSuccess = false,
                };
            var patientgames = await _gameservice.GetAllGamesByPatientId(patientid);
            if(patientgames==null || patientgames.Data.Count() <= 0)
                return new Response<List<int[]>>
                {
                    Message = "There is no patient with this id",
                    IsSuccess = false,
                };
            int[] monthsTotal=new int[12];
            int[] monthscorrect = new int[12];
            foreach (var game in patientgames.Data)
            {
                var gamehistory = await _gamemovementservice.GetAllGameMovementsByGameId(game.Id);
                int monthsnumber = game.Date.Month;
                foreach(var gamemovement in gamehistory.Data)
                {
                    monthsTotal[monthsnumber-1]+=1;
                    if(gamemovement.ActualMovement==gamemovement.RequiredMovement)
                        monthscorrect[monthsnumber-1]+=1;
                }
            }

            List<int[]> mergedList = new List<int[]>();

            for (int i = 0; i < monthsTotal.Length; i++)
            {
                mergedList.Add(new int[] { monthscorrect[i], monthsTotal[i] });
            }

            return new Response<List<int[]>>
            {
                Message = "This is the list of Progress",
                IsSuccess = true,
                Data = mergedList
            };

        }
    
        public async Task<Response<PatientVM>> GetPatientDetails(string patientid)
        {
            PatientVM patientdata = new PatientVM();
            var roleattributevalues = await _roleattributevalueservice.GetAllRoleAttributeValuesByUserId(patientid);

            foreach (var roleattributevalue in roleattributevalues.Data)
            {
                var roleattribute = await _roleattributeservice.GetRoleAttributesById(roleattributevalue.Id);
                if (roleattribute == null) return null;
                var attribute = await _attributeservice.GetAttributeById(roleattribute.Data.AttributeId);
                patientdata.PatientAttributes[attribute.Data.AttributeName] = roleattributevalue.Value;
            }
            return new Response<PatientVM>()
            {
                Message = "This is the Patient Data",
                IsSuccess = true,
                Data = patientdata
            };
        }
        public async Task<Response<List<PatientVM>>> GetDoctorPatients(string doctorid)
        {
            List<PatientVM> patientslist = [];

            var user = await _userManager.FindByIdAsync(doctorid);
            if (user == null)
            {
                return new Response<List<PatientVM>>()
                {
                    Message = "Error getting dr data",
                    IsSuccess = false,
                };
            }

            var drpatientslist= await _drpatientsservice.GetAllDrPatientsByDoctorId(user.Id);

            foreach (var drpatient in drpatientslist.Data)
            {
                var patient = await GetPatientDetails(drpatient.PatientId);

                patientslist.Add(patient.Data);
            }

            return new Response<List<PatientVM>> ()
            {
                Message = "This is the patient list for the specified doctor",
                IsSuccess = true,
                Data = patientslist
            };

        }
    }
}
