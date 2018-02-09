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
            if (!newComment.UserId.IsAuthorOrAdmin(User))
            {
                Unauthorized();
            }
            try
            {
                var commentId = await _postCommentService.AddAsync(newComment.UserId, newComment.PostId, newComment.Content);
                return Created($"comments/{commentId}", null);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
                return BadRequest(e.Message);
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
                return BadRequest(e.Message);
            }
        }

        //GET comments
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var comments = await _postCommentService.GetAllAsync();
                if (comments == null)
                {
                    NotFound();
                }
                return Json(comments);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Update
        //PUT comments/post/guid
        [Authorize]
        [HttpPut("post/{postId}")]
        public async Task<IActionResult> UpdateAsync(Guid postId, [FromBody] CommentDto updatedComment)
        {
            if (!updatedComment.UserId.IsAuthorOrAdmin(User))
            {
                Unauthorized();
            }
            try
            {
                await _postCommentService.UpdateAsync(postId, updatedComment);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
                if (!comment.UserId.IsAuthorOrAdmin(User))
                {
                    Unauthorized();
                }
                await _postCommentService.DeleteAsync(postId, commentId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
