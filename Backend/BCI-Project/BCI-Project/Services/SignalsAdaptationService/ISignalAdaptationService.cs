using BCI_Project.Response;
using BCI_Project.ViewModels;

namespace BCI_Project.Services.SignalsAdaptaionService
{
    public interface ISignalAdaptationService
    {
        Task<Response<ICollection<SignalsAdaptationVM>>> GetAllSignalsAdaptations();
        Task<Response<SignalsAdaptationVM>> GetSignalsAdaptationById(Guid id);
        Task<Response<SignalsAdaptationVM>> AddSignalsAdaptation(SignalsAdaptationVM signalsadaptation);
        Task<Response<SignalsAdaptationVM>> UpdateSignalsAdaptation(SignalsAdaptationVM signalsadaptation);
        Task<Response<SignalsAdaptationVM>> DeleteSignalsAdaptation(Guid id);
    }
}
