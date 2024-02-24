using BCI_Project.Models;
using BCI_Project.Response;
using BCI_Project.UnitOfWork;
using BCI_Project.ViewModels;

namespace BCI_Project.Services.SignalsAdaptaionService
{
    public class SignalAdaptationService : ISignalAdaptationService
    {
        private readonly IUnitOfWork _unitofwork;
        public SignalAdaptationService(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Response<ICollection<SignalsAdaptationVM>>> GetAllSignalsAdaptations()
        {
            var signalsadaptation = _unitofwork.SignalsAdaptation.GetAll().Select(a => new SignalsAdaptationVM()
            {
                Id = a.Id,
                PatientId = a.PatientId,
                Date = a.Date,
                FeatureArray = a.FeatureArray,
            }).ToList();

            if (signalsadaptation == null || signalsadaptation.Count() <= 0)
            {
                return new Response<ICollection<SignalsAdaptationVM>>()
                {
                    Message = "No SignalsAdaptation Items",
                    IsSuccess = true
                };
            }

            return new Response<ICollection<SignalsAdaptationVM>>()
            {
                Message = "These are the SignalsAdaptation Items",
                IsSuccess = true,
                Data = signalsadaptation
            };
        }
        public async Task<Response<SignalsAdaptationVM>> GetSignalsAdaptationById(Guid id)
        {
            var signalsadaptation = _unitofwork.SignalsAdaptation.GetById(id);
            if (signalsadaptation == null)
                return new Response<SignalsAdaptationVM>()
                {
                    Message = "No SignalsAdaptation Item with this Id",
                    IsSuccess = true
                };
            SignalsAdaptationVM signalsadaptationitem = new SignalsAdaptationVM()
            {
                Id = signalsadaptation.Id,
                PatientId= signalsadaptation.PatientId,
                Date = signalsadaptation.Date,
                FeatureArray = signalsadaptation.FeatureArray,
            };
            return new Response<SignalsAdaptationVM>()
            {
                Message = "SignalsAdaptation is available",
                IsSuccess = true,
                Data = signalsadaptationitem
            };
        }
        public async Task<Response<SignalsAdaptationVM>> AddSignalsAdaptation(SignalsAdaptationVM signalsadaptation)
        {
            if (signalsadaptation == null)
            {
                return new Response<SignalsAdaptationVM>()
                {
                    Message = "SignalsAdaptaion is null",
                    IsSuccess = false
                };
            }
            SignalsAdaptation _signalsadaptation = new SignalsAdaptation()
            {
                PatientId = signalsadaptation.PatientId,
                Date = signalsadaptation.Date,
                FeatureArray = signalsadaptation.FeatureArray,
                IsDeleted = false
            };
            var addedsignalsadaptation = _unitofwork.SignalsAdaptation.Add(_signalsadaptation);
            if (addedsignalsadaptation == null)
                return new Response<SignalsAdaptationVM>()
                {
                    Message = "Can't add SignalsAdaptation",
                    IsSuccess = false
                };
            _unitofwork.Save();
            signalsadaptation.Id = _signalsadaptation.Id;
            return new Response<SignalsAdaptationVM>()
            {
                Message = "SignalsAdaptation Added Succesfully",
                IsSuccess = true,
                Data = signalsadaptation
            };
        }
        public async Task<Response<SignalsAdaptationVM>> UpdateSignalsAdaptation(SignalsAdaptationVM signalsadaptation)
        {
            if (signalsadaptation == null)
            {
                return new Response<SignalsAdaptationVM>()
                {
                    Message = "SignalsAdaptation is null",
                    IsSuccess = false
                };
            }
            var _signalsadaptation = _unitofwork.SignalsAdaptation.GetById(signalsadaptation.Id);
            if (_signalsadaptation == null)
            {
                return new Response<SignalsAdaptationVM>()
                {
                    Message = "No SignalsAdaptation with this id",
                    IsSuccess = false
                };
            }
            _signalsadaptation.PatientId = signalsadaptation.PatientId;
            _signalsadaptation.Date = signalsadaptation.Date;
            _signalsadaptation.FeatureArray = signalsadaptation.FeatureArray;

            var updatedsignalsadaptation = _unitofwork.SignalsAdaptation.Update(_signalsadaptation);
            if (updatedsignalsadaptation == null)
                return new Response<SignalsAdaptationVM>()
                {
                    Message = "Can't Update SignalsAdaptation",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<SignalsAdaptationVM>()
            {
                Message = "SignalsAdaptation Updated Succesfully",
                IsSuccess = true,
                Data = signalsadaptation
            };
        }
        public async Task<Response<SignalsAdaptationVM>> DeleteSignalsAdaptation(Guid id)
        {
            var _signalsadaptation = _unitofwork.SignalsAdaptation.GetById(id);
            if (_signalsadaptation == null)
            {
                return new Response<SignalsAdaptationVM>()
                {
                    Message = "No SignalsAdaptation with this id",
                    IsSuccess = false
                };
            }
            var deletedsignalsadaptation = _unitofwork.SignalsAdaptation.Delete(id);
            if (deletedsignalsadaptation != null)
                return new Response<SignalsAdaptationVM>()
                {
                    Message = "Can't delete SignalsAdaptation",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<SignalsAdaptationVM>()
            {
                Message = "SignalsAdaptation Deleted Successfully",
                IsSuccess = true
            };
        }
    }
}
