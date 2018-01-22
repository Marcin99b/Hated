using System;
using System.Threading.Tasks;
using Hated.Infrastructure.DTO;
using Hated.Infrastructure.Services;
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
        //POST api/comment/post/guid - post
        [HttpPost("post/{postId}")]
        public async Task<IActionResult> AddAsync(Guid postId, [FromBody]CommentDto newComment)
        {
            var commentId = await _postCommentService.AddAsync(newComment.UserId, postId, newComment.Content);
            return Created($"api/comments/{commentId}", null);
        }

        //Read
        //GET api/comments/guid
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

        //Read
        //GET api/comments/post/guid
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

        //GET api/comments
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
        //PUT api/comments/post/guid
        [HttpPut("post/{postId}")]
        public async Task<IActionResult> UpdateAsync(Guid postId, [FromBody] CommentDto updatedComment)
        {
            await _postCommentService.UpdateAsync(postId, updatedComment);
            return Ok();
        }

        //Delete
        //DELETE api/comments/post/guid
        [HttpDelete("{postId}/{commentId}")]
        public async Task<IActionResult> DeleteAsync(Guid postId, Guid commentId)
        {
            await _postCommentService.DeleteAsync(postId, commentId);
            return Ok();
        }

    }
}
