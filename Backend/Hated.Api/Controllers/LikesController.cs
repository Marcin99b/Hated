using System;
using System.Threading.Tasks;
using Hated.Infrastructure.DTO;
using Hated.Infrastructure.Extensions;
using Hated.Infrastructure.Services.Like;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hated.Api.Controllers
{
    public class LikesController : BaseController
    {
        private readonly IPostLikeService _postLikeService;
        private readonly IPostCommentLikeService _postCommentLikeService;
        private readonly ILogger<ActivationController> _logger;

        public LikesController(IPostLikeService postLikeService, IPostCommentLikeService postCommentLikeService, ILogger<ActivationController> logger)
        {
            _postLikeService = postLikeService;
            _postCommentLikeService = postCommentLikeService;
            _logger = logger;
        }

        [Authorize]
        [HttpPost("post{postId}/like")]
        public async Task<IActionResult> LikePostAsync(int postId)
        {
            try
            {
                var userId = User.GetUserId();
                await _postLikeService.LikePostAsync(postId, userId);
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

        [Authorize]
        [HttpPost("post{postId}/dislike")]
        public async Task<IActionResult> DisikePostAsync(int postId)
        {
            try
            {
                var userId = User.GetUserId();
                await _postLikeService.DislikePostAsync(postId, userId);
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

        [Authorize]
        [HttpPost("post{postId}/comment/{commentId}/like")]
        public async Task<IActionResult> LikeCommentAsync(int postId, Guid commentId)
        {
            try
            {
                var userId = User.GetUserId();
                await _postCommentLikeService.LikePostCommentAsync(postId, commentId, userId);
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

        [Authorize]
        [HttpPost("post{postId}/comment/{commentId}/dislike")]
        public async Task<IActionResult> DislikeCommentAsync(int postId, Guid commentId)
        {
            try
            {
                var userId = User.GetUserId();
                await _postCommentLikeService.DislikePostCommentAsync(postId, commentId, userId);
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
