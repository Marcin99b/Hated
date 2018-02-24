using System;
using System.Threading.Tasks;
using Hated.Infrastructure.Commands.Comment;
using Hated.Infrastructure.DTO;
using Hated.Infrastructure.Extensions;
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
            try
            {
                var commentId = await _postCommentService.AddAsync(User.GetUserId(), newComment.PostId, newComment.Content);
                return Created($"comments/{commentId}", null);
            }
            catch (Exception e)
            {
                return Json(new ExceptionDto
                {
                    Error = e.Message
                });
            }
        }

        //Read
        //GET comments/guid
        [HttpGet("{commentId}")]
        public async Task<IActionResult> GetAsync(Guid commentId)
        {
            try
            {
                var comment = await _postCommentService.GetAsync(commentId);
                if (comment == null)
                {
                    return NotFound();
                }
                return Json(comment);
            }
            catch (Exception e)
            {
                return Json(new ExceptionDto
                {
                    Error = e.Message
                });
            }
        }
        
        //GET comments/post/guid
        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetAllAsyncFromPostAsync(Guid postId)
        {
            try
            {
                var comments = await _postCommentService.GetAllFromPostAsync(postId);
                if (comments == null)
                {
                    NotFound();
                }
                return Json(comments);
            }
            catch (Exception e)
            {
                return Json(new ExceptionDto
                {
                    Error = e.Message
                });
            }
        }

        //GET comments
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var comments = await _postCommentService.GetAllAsync();
                return Json(comments);
            }
            catch (Exception e)
            {
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
                var comment = await _postCommentService.GetAsync(commentId);
                if (!comment.UserId.HavePermissions(User))
                {
                    return Unauthorized();
                }
                await _postCommentService.DeleteAsync(postId, commentId);
                return Ok();
            }
            catch (Exception e)
            {
                return Json(new ExceptionDto
                {
                    Error = e.Message
                });
            }
        }

    }
}
