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
        Task<Response<List<int[]>>> GetTreatmentProgressByPatientId(string patientid);
        Task<Response<List<PatientVM>>> GetDoctorPatients(string doctorid);
        Task<Response<List<DoctorVM>>> GetAllDoctors();
        Task<Response<PatientVM>> GetPatientDetails(string patientid);

        Task<Response<Object>> AddDoctor(RegisterVM user);

    }
}
