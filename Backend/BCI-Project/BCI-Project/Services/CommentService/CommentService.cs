using BCI_Project.Models;
using BCI_Project.Response;
using BCI_Project.UnitOfWork;
using BCI_Project.ViewModels;

namespace BCI_Project.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitofwork;
        public CommentService(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Response<ICollection<CommentVM>>> GetAllComments()
        {
            var comments = _unitofwork.Comment.GetAll().Select(a => new CommentVM()
            {
                Id = a.Id,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                Message = a.Message,
                Sender=a.Sender,
                Date = a.Date,
            }).ToList();

            if (comments == null || comments.Count() <= 0)
            {
                return new Response<ICollection<CommentVM>>()
                {
                    Message = "No Comment Items",
                    IsSuccess = true
                };
            }

            return new Response<ICollection<CommentVM>>()
            {
                Message = "These are the Comment Items",
                IsSuccess = true,
                Data = comments
            };
        }
        public async Task<Response<CommentVM>> GetCommentById(Guid id)
        {
            var comment = _unitofwork.Comment.GetById(id);
            if (comment == null)
                return new Response<CommentVM>()
                {
                    Message = "No Comment Item with this Id",
                    IsSuccess = true
                };
            CommentVM commentitem = new CommentVM()
            {
                Id= comment.Id,
                PatientId= comment.PatientId,
                DoctorId= comment.DoctorId,
                Message = comment.Message,
                Sender= comment.Sender,
                Date = comment.Date,
            };
            return new Response<CommentVM>()
            {
                Message = "Comment is available",
                IsSuccess = true,
                Data = commentitem
            };
        }
        public async Task<Response<CommentVM>> AddComment(CommentVM comment)
        {
            if (comment == null)
            {
                return new Response<CommentVM>()
                {
                    Message = "Comment is null",
                    IsSuccess = false
                };
            }
            Comments _comment = new Comments()
            {
                PatientId = comment.PatientId,
                DoctorId = comment.DoctorId,
                Message = comment.Message,
                Sender = comment.Sender,
                Date = comment.Date,
                IsDeleted = false
            };
            var addedcomment = _unitofwork.Comment.Add(_comment);
            if (addedcomment == null)
                return new Response<CommentVM>()
                {
                    Message = "Can't add Comment",
                    IsSuccess = false
                };
            _unitofwork.Save();
            comment.Id = _comment.Id;
            return new Response<CommentVM>()
            {
                Message = "Comment Added Succesfully",
                IsSuccess = true,
                Data = comment
            };
        }
        public async Task<Response<CommentVM>> UpdateComment(CommentVM comment)
        {
            if (comment == null)
            {
                return new Response<CommentVM>()
                {
                    Message = "Comment is null",
                    IsSuccess = false
                };
            }
            var _comment = _unitofwork.Comment.GetById(comment.Id);
            if (_comment == null)
            {
                return new Response<CommentVM>()
                {
                    Message = "No Comment with this id",
                    IsSuccess = false
                };
            }
            _comment.PatientId = comment.PatientId;
            _comment.DoctorId = comment.DoctorId;
            _comment.Message = comment.Message;
            _comment.Sender= comment.Sender;
            _comment.Date = comment.Date;

            var updatedcomment = _unitofwork.Comment.Update(_comment);
            if (updatedcomment == null)
                return new Response<CommentVM>()
                {
                    Message = "Can't Update Comment",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<CommentVM>()
            {
                Message = "Comment Updated Succesfully",
                IsSuccess = true,
                Data = comment
            };
        }
        public async Task<Response<CommentVM>> DeleteComment(Guid id)
        {
            var _comment = _unitofwork.Comment.GetById(id);
            if (_comment == null)
            {
                return new Response<CommentVM>()
                {
                    Message = "No Comment with this id",
                    IsSuccess = false
                };
            }
            var deletedcomment = _unitofwork.Comment.Delete(id);
            if (deletedcomment != null)
                return new Response<CommentVM>()
                {
                    Message = "Can't delete Comment",
                    IsSuccess = false
                };
            _unitofwork.Save();
            return new Response<CommentVM>()
            {
                Message = "Comment Deleted Successfully",
                IsSuccess = true
            };
        }
        public async Task<Response<ICollection<CommentVM>>> GetAllCommentsByPatientId(string id)
        {
            var comments = _unitofwork.Comment.GetAll().Select(a => new CommentVM()
            {
                Id = a.Id,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                Message = a.Message,
                Sender = a.Sender,
                Date = a.Date,
            }).Where(b=>b.PatientId==id).OrderBy(a=>a.Date) .ToList();

            if (comments == null || comments.Count() <= 0)
            {
                return new Response<ICollection<CommentVM>>()
                {
                    Message = "No Comment Items for this patient",
                    IsSuccess = true
                };
            }

            return new Response<ICollection<CommentVM>>()
            {
                Message = "These are the Comment Items for this patient",
                IsSuccess = true,
                Data = comments
            };
        }

        public async Task<Response<ICollection<CommentVM>>> GetAllCommentsByDoctorId(string id)
        {
            var comments = _unitofwork.Comment.GetAll().Select(a => new CommentVM()
            {
                Id = a.Id,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                Message = a.Message,
                Sender = a.Sender,
                Date = a.Date,
            }).Where(b => b.DoctorId == id).OrderBy(a => a.Date).ToList();

            if (comments == null || comments.Count() <= 0)
            {
                return new Response<ICollection<CommentVM>>()
                {
                    Message = "No Comment Items for this patient",
                    IsSuccess = true
                };
            }

            return new Response<ICollection<CommentVM>>()
            {
                Message = "These are the Comment Items for this patient",
                IsSuccess = true,
                Data = comments
            };
        }
    }
}
