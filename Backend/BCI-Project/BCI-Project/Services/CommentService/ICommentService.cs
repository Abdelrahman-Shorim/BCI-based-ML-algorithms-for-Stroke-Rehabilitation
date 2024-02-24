using BCI_Project.Response;
using BCI_Project.ViewModels;

namespace BCI_Project.Services.CommentService
{
    public interface ICommentService
    {
        Task<Response<ICollection<CommentVM>>> GetAllComments();
        Task<Response<CommentVM>> GetCommentById(Guid id);
        Task<Response<CommentVM>> AddComment(CommentVM comment);
        Task<Response<CommentVM>> UpdateComment(CommentVM comment);
        Task<Response<CommentVM>> DeleteComment(Guid id);
        Task<Response<ICollection<CommentVM>>> GetAllCommentsByPatientId(Guid id);
    }
}
