using System;
using System.Threading.Tasks;
using Hated.Infrastructure.Commands.Posts;
using Hated.Infrastructure.DTO;
using Hated.Infrastructure.Extensions;
using Hated.Infrastructure.Services.PostService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hated.Api.Controllers
{
    public class PostsController : BaseController
    {
        private readonly IPostService _postService;
        private readonly ILogger<PostsController> _logger;

        public PostsController(IPostService postService, ILogger<PostsController> logger)
        {
            _postService = postService;
            _logger = logger;
        }

        //Create
        //POST posts
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]CreatePost newPost)
        {
            try
            {
                var postId = await _postService.AddAsync(User.GetUserId(), newPost.Title, newPost.Content);
                return Created($"posts/{postId}", null);
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
        //GET posts/id
        [HttpGet("{postId}")]
        public async Task<IActionResult> GetAsync(int postId, int commentsFrom = 0, int commentsNumber = 10)
        {
            try
            {
                var post = await _postService.GetAsync(postId, commentsFrom, commentsNumber);
                if (post == null)
                {
                    return NotFound();
                }
                return Json(post);
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

        //GET posts
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int from = 0, int number = 10)
        {
            try
            {
                var posts = await _postService.GetAllAsync(from, number);
                if (posts == null)
                {
                    return NotFound();
                }
                return Json(posts);
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
        //PUT posts
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]UpdatePost updatedPost, string adminComment = "")
        {
            try
            {
                if (!updatedPost.Author.IsAuthor(User))
                {
                    return Unauthorized();
                }
                if (User.IsAdmin())
                {
                    await _postService.UpdateByAdminAsync(updatedPost.Id, updatedPost.Title, updatedPost.Content, User.GetUserId(), adminComment);
                }
                await _postService.UpdateAsync(updatedPost.Id, updatedPost.Title, updatedPost.Content);
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
        //DELETE posts/guid
        [Authorize]
        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeleteAsync(int postId)
        {
            try
            {
                var post = await _postService.GetAsync(postId, 0, 0);
                if (!post.Author.Id.HavePermissions(User))
                {
                    return Unauthorized();
                }
                await _postService.DeleteAsync(postId);
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
