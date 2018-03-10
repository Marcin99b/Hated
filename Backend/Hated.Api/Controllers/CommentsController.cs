using System;
using System.Threading.Tasks;
using Hated.Infrastructure.Commands.Comment;
using Hated.Infrastructure.DTO;
using Hated.Infrastructure.Extensions;
using Hated.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hated.Api.Controllers
{
    public class CommentsController : BaseController
    {
        private readonly IPostCommentService _postCommentService;
        private readonly ILogger<CommentsController> _logger;

        public CommentsController(IPostCommentService postCommentService, ILogger<CommentsController> logger)
        {
            _postCommentService = postCommentService;
            _logger = logger;
        }
        //Create
        //POST comments
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]CreateComment newComment)
        {
            try
            {
                var commentId = await _postCommentService.AddAsync(User.GetUserId(), newComment.PostId, newComment.Content);
                return Created($"comments/post/{newComment.PostId}/comment/{commentId}", null);
            }
            catch (Exception e)
            {
                _logger.LogError($"Returning exception: {e.Message}");
                return Json(new ExceptionDto
                {
                    Error = e.Message
                });
            }
        }

        //Read
        //GET comments/post/id/comment/id
        [HttpGet("post/{postId}/comment/{commentId}")]
        public async Task<IActionResult> GetAsyncFromPost(Guid postId, Guid commentId)
        {
            try
            {
                var comment = await _postCommentService.GetAsyncFromPost(postId, commentId);
                return Json(comment);
            }
            catch (Exception e)
            {
                _logger.LogError($"Returning exception: {e.Message}");
                return Json(new ExceptionDto
                {
                    Error = e.Message
                });
            }
        }
        
        //GET comments/post/id
        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetAllAsyncFromPostAsync(Guid postId, int from = 0, int number = 10)
        {
            try
            {
                var comments = await _postCommentService.GetAllFromPostAsync(postId, from, number);
                if (comments == null)
                {
                    NotFound();
                }
                return Json(comments);
            }
            catch (Exception e)
            {
                _logger.LogError($"Returning exception: {e.Message}");
                return Json(new ExceptionDto
                {
                    Error = e.Message
                });
            }
        }

        //Update
        //PUT comments/post/guid
        [Authorize]
        [HttpPut("post/{postId}")]
        public async Task<IActionResult> UpdateAsync(Guid postId, [FromBody] CommentDto updatedComment)
        {
            if (!updatedComment.UserId.HavePermissions(User))
            {
                return Unauthorized();
            }
            try
            {
                await _postCommentService.UpdateAsync(postId, updatedComment);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"Returning exception: {e.Message}");
                return Json(new ExceptionDto
                {
                    Error = e.Message
                });
            }
        }

        //Delete
        //DELETE comments/post/guid/comment/guid
        [Authorize]
        [HttpDelete("post/{postId}/comment/{commentId}")]
        public async Task<IActionResult> DeleteAsync(Guid postId, Guid commentId)
        {
            try
            {
                var comment = await _postCommentService.GetAsyncFromPost(postId, commentId);
                if (!comment.UserId.HavePermissions(User))
                {
                    return Unauthorized();
                }
                await _postCommentService.DeleteAsync(postId, commentId);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"Returning exception: {e.Message}");
                return Json(new ExceptionDto
                {
                    Error = e.Message
                });
            }
        }

    }
}
