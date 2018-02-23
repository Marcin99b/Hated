using System;
using System.Threading.Tasks;
using Hated.Infrastructure.Commands.Posts;
using Hated.Infrastructure.DTO;
using Hated.Infrastructure.Extensions;
using Hated.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hated.Api.Controllers
{
    public class PostsController : BaseController
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        //Create
        //POST posts
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]CreatePost newPost)
        {
            if (!newPost.UserId.HavePermissions(User))
            {
                return Unauthorized();
            }
            try
            {
                var postId = await _postService.AddAsync(newPost.UserId, newPost.Content);
                return Created($"posts/{postId}", null);
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
        //GET posts/guid
        [HttpGet("{postId}")]
        public async Task<IActionResult> GetAsync(Guid postId)
        {
            try
            {
                var post = await _postService.GetAsync(postId);
                if (post == null)
                {
                    return NotFound();
                }
                return Json(post);
            }
            catch (Exception e)
            {
                return Json(new ExceptionDto
                {
                    Error = e.Message
                });
            }
        }

        //GET posts
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var posts = await _postService.GetAllAsync();
                if (posts == null)
                {
                    return NotFound();
                }
                return Json(posts);
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
        //PUT posts
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]PostDto updatedPost)
        {
            try
            {
                if (!updatedPost.UserId.HavePermissions(User))
                {
                    return Unauthorized();
                }
                await _postService.UpdateAsync(updatedPost);
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
        //DELETE posts/guid
        [Authorize]
        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeleteAsync(Guid postId)
        {
            try
            {
                var post = await _postService.GetAsync(postId);
                if (!post.UserId.HavePermissions(User))
                {
                    return Unauthorized();
                }
                await _postService.DeleteAsync(postId);
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
