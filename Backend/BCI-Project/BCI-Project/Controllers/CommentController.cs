using BCI_Project.Services.CommentService;
using BCI_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BCI_Project.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentservice;
        public CommentController(ICommentService commentservice)
        {
            _commentservice = commentservice;
        }


        [HttpGet(nameof(GetAllComments))]
        public async Task<IActionResult> GetAllComments()
        {
            var result = await _commentservice.GetAllComments();
            return Ok(result);
        }

        [HttpGet(nameof(GetAllCommentsByPatientId))]
        public async Task<IActionResult> GetAllCommentsByPatientId(string id)
        {
            var result = await _commentservice.GetAllCommentsByPatientId(id);
            return Ok(result);
        }

        [HttpGet(nameof(GetAllCommentsByDoctorId))]
        public async Task<IActionResult> GetAllCommentsByDoctorId(string id)
        {
            var result = await _commentservice.GetAllCommentsByDoctorId(id);
            return Ok(result);
        }

        [HttpGet(nameof(GetCommentById))]
        public async Task<IActionResult> GetCommentById(Guid id)
        {
            var result = await _commentservice.GetCommentById(id);
            return Ok(result);
        }

        [HttpPost(nameof(AddComment))]
        public async Task<IActionResult> AddComment([FromBody] CommentVM _comment)
        {
            var result = await _commentservice.AddComment(_comment);
            return Ok(result);
        }

        [HttpPut(nameof(UpdateComment))]
        public async Task<IActionResult> UpdateComment([FromBody] CommentVM _comment)
        {
            var result = await _commentservice.UpdateComment(_comment);
            return Ok(result);
        }

        [HttpDelete(nameof(DeleteComment))]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            var result = await _commentservice.DeleteComment(id);
            return Ok(result);
        }
    }
}
