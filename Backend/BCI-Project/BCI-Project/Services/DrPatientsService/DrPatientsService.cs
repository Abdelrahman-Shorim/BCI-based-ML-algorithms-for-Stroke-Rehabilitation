using BCI_Project.Models;
using BCI_Project.Response;
using BCI_Project.UnitOfWork;
using BCI_Project.ViewModels;

namespace BCI_Project.Services.DrPatientsService
{
    public class DrPatientsService : IDrPatientsService
    {
        private readonly IUnitOfWork _unitofwork;
        public DrPatientsService(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Response<ICollection<DrPatientsVM>>> GetAllDrPatients()
        {
            var drpatients = _unitofwork.DrPatients.GetAll().Select(a => new DrPatientsVM()
            {
                Id = a.Id,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
            }).ToList();

            if (drpatients == null || drpatients.Count() <= 0)
            {
                return new Response<ICollection<DrPatientsVM>>()
                {
                    Message = "No DrPatients Items",
                    IsSuccess = true
                };
            }

            return new Response<ICollection<DrPatientsVM>>()
            {
                Message = "These are the DrPatients Items",
                IsSuccess = true,
                Data = drpatients
            };
        }
        public async Task<Response<DrPatientsVM>> GetDrPatientsById(Guid id)
        {
            var drpatients = _unitofwork.DrPatients.GetById(id);
            if (drpatients == null)
                return new Response<DrPatientsVM>()
                {
                    Message = "No DrPatients Item with this Id",
                    IsSuccess = true
                };
            DrPatientsVM drpatientsitem = new DrPatientsVM()
            {
                Id = drpatients.Id,
                PatientId=drpatients.PatientId,
                DoctorId=drpatients.DoctorId,
            };
            return new Response<DrPatientsVM>()
            {
                Message = "DrPatients is available",
                IsSuccess = true,
                Data = drpatientsitem
            };
        }
        public async Task<Response<DrPatientsVM>> AddDrPatients(DrPatientsVM drpatients)
        {
            if (drpatients == null)
            {
                return new Response<DrPatientsVM>()
                {
                    Message = "DrPatients is null",
                    IsSuccess = false
                };
            }
            DrPatients _drpatients = new DrPatients()
            {
                PatientId = drpatients.PatientId,
                DoctorId=drpatients.DoctorId,
                IsDeleted = false
            };
            var addeddrpatients = _unitofwork.DrPatients.Add(_drpatients);
            if (addeddrpatients == null)
                return new Response<DrPatientsVM>()
                {
                    Message = "Can't add DrPatients",
                    IsSuccess = false
                };
            _unitofwork.Save();
            drpatients.Id = _drpatients.Id;
            return new Response<DrPatientsVM>()
            {
                Message = "DrPatients Added Succesfully",
                IsSuccess = true,
                Data = drpatients
            };
        }
        public async Task<Response<DrPatientsVM>> UpdateDrPatients(DrPatientsVM drpatients)
        {
            if (drpatients == null)
            {
                return new Response<DrPatientsVM>()
                {
                    Message = "DrPatients is null",
                    IsSuccess = false
                };
            }
            var _drpatients = _unitofwork.DrPatients.GetById(drpatients.Id);
            if (_drpatients == null)
            {
                return new Response<DrPatientsVM>()
                {
                    Message = "No DrPatients with this id",
                    IsSuccess = false
                };
            }
            _drpatients.PatientId = drpatients.PatientId;
            _drpatients.DoctorId = drpatients.DoctorId;

            var updateddrpatients = _unitofwork.DrPatients.Update(_drpatients);
            if (updateddrpatients == null)
                return new Response<DrPatientsVM>()
                {
                    Message = "Can't Update DrPatients",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<DrPatientsVM>()
            {
                Message = "DrPatients Updated Succesfully",
                IsSuccess = true,
                Data = drpatients
            };
        }
        public async Task<Response<DrPatientsVM>> DeleteDrPatients(Guid id)
        {
            var _drpatients = _unitofwork.DrPatients.GetById(id);
            if (_drpatients == null)
            {
                return new Response<DrPatientsVM>()
                {
                    Message = "No DrPatients with this id",
                    IsSuccess = false
                };
            }
            var deleteddrpatients = _unitofwork.DrPatients.Delete(id);
            if (deleteddrpatients != null)
                return new Response<DrPatientsVM>()
                {
                    Message = "Can't delete DrPatients",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<DrPatientsVM>()
            {
                Message = "DrPatients Deleted Successfully",
                IsSuccess = true
            };
        }
        public async Task<Response<ICollection<DrPatientsVM>>> GetAllDrPatientsByDoctorId(string id)
        {
            var drpatients = _unitofwork.DrPatients.GetAll().Select(a => new DrPatientsVM()
            {
                Id = a.Id,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
            }).Where(b=>b.DoctorId==id).ToList();

            if (drpatients == null || drpatients.Count() <= 0)
            {
                return new Response<ICollection<DrPatientsVM>>()
                {
                    Message = "No DrPatients Items for this doctor Id",
                    IsSuccess = true
                };
            }

            return new Response<ICollection<DrPatientsVM>>()
            {
                Message = "These are the DrPatients Items for this doctor Id",
                IsSuccess = true,
                Data = drpatients
            };
        }
        public async Task<Response<DrPatientsVM>> GetPatientDoctorByPatientId(string patientid)
        {
            var drpatients = _unitofwork.DrPatients.GetAll().Select(a => new DrPatientsVM()
            {
                Id = a.Id,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
            }).Where(a=>a.PatientId==patientid)
                .ToList();

            if (drpatients == null || drpatients.Count() <= 0)
            {
                return new Response<DrPatientsVM>()
                {
                    Message = "No assighned patient Items",
                    IsSuccess = true
                };
            }

            return new Response<DrPatientsVM>()
            {
                Message = "These are the DrPatients Items",
                IsSuccess = true,
                Data = drpatients.First()
            };
        }
    }
}
