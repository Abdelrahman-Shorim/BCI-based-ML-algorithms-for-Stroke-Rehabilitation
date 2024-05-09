using BCI_Project.Models;
using BCI_Project.Response;
using BCI_Project.ViewModels.UserVM;

namespace BCI_Project.Services.UserService
{
    public interface IUserService
    {
        Task<Response<Object>> RegisterUserAsync(RegisterVM user);
        Task<Response<Object>> LoginUserAsync(LoginVM user);
        Task<Response<Object>> AddTargetToPatient(string patientid, int target);
        Task<Response<Object>> GetTreatmentProgressByPatientId(string patientid);
    }
}
