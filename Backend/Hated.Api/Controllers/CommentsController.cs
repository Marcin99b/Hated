using System;
using System.Threading.Tasks;
using Hated.Infrastructure.Commands.Comment;
using Hated.Infrastructure.DTO;
using Hated.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hated.Api.Controllers
{
    public class CommentsController : BaseController
    {
        private readonly IPostCommentService _postCommentService;

        public CommentsController(IPostCommentService postCommentService)
        {
            _postCommentService = postCommentService;
        }
        //Create
        //POST comments
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]CreateComment newComment)
        {
            var commentId = await _postCommentService.AddAsync(newComment.UserId, newComment.PostId, newComment.Content);
            return Created($"comments/{commentId}", null);
        }

        //Read
        //GET comments/guid
        [HttpGet("{commentId}")]
        public async Task<IActionResult> GetAsync(Guid commentId)
        {
            var comment = await _postCommentService.GetAsync(commentId);
            if (comment == null)
            {
                return NotFound();
            }

            return Json(comment);
        }
        
        //GET comments/post/guid
        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetAllAsyncFromPostAsync(Guid postId)
        {
            var comments = await _postCommentService.GetAllFromPostAsync(postId);
            if (comments == null)
            {
                NotFound();
            }
            return Json(comments);
        }

        //GET comments
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var comments = await _postCommentService.GetAllAsync();
            if (comments == null)
            {
                NotFound();
            }
            return Json(comments);
        }

        //Update
        //PUT comments/post/guid
        [Authorize]
        [HttpPut("post/{postId}")]
        public async Task<IActionResult> UpdateAsync(Guid postId, [FromBody] CommentDto updatedComment)
        {
            await _postCommentService.UpdateAsync(postId, updatedComment);
            return Ok();
        }

        //Delete
        //DELETE comments/post/guid/comment/guid
        [Authorize]
        [HttpDelete("post/{postId}/comment/{commentId}")]
        public async Task<IActionResult> DeleteAsync(Guid postId, Guid commentId)
        {
            await _postCommentService.DeleteAsync(postId, commentId);
            return Ok();
        }

    }
}
