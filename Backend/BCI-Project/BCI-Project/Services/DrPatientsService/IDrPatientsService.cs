using BCI_Project.Response;
using BCI_Project.ViewModels;

namespace BCI_Project.Services.DrPatientsService
{
    public interface IDrPatientsService
    {
        Task<Response<ICollection<DrPatientsVM>>> GetAllDrPatients();
        Task<Response<DrPatientsVM>> GetDrPatientsById(Guid id);
        Task<Response<DrPatientsVM>> AddDrPatients(DrPatientsVM drpatients);
        Task<Response<DrPatientsVM>> UpdateDrPatients(DrPatientsVM drpatients);
        Task<Response<DrPatientsVM>> DeleteDrPatients(Guid id);
        Task<Response<ICollection<DrPatientsVM>>> GetAllDrPatientsByDoctorId(Guid id);
    }
}
