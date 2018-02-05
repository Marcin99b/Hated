﻿using System;
using System.Threading.Tasks;
using Hated.Infrastructure.Commands.Posts;
using Hated.Infrastructure.DTO;
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
        //POST api/posts
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]CreatePost newPost)
        {
            var postId = await _postService.AddAsync(newPost.UserId, newPost.Content);
            return Created($"api/posts/{postId}", null);
        }

        //Read
        //GET api/posts/guid
        [HttpGet("{postId}")]
        public async Task<IActionResult> GetAsync(Guid postId)
        {
            var post = await _postService.GetAsync(postId);
            if (post == null)
            {
               return NotFound();
            }

            return Json(post);
        }

        //GET api/posts
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var posts = await _postService.GetAllAsync();
            if (posts == null)
            {
                return NotFound();
            }

            return Json(posts);
        }

        //Update
        //PUT api/posts
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]PostDto updatedPost)
        {
            await _postService.UpdateAsync(updatedPost);
            return Ok();
        }

        //Delete
        //DELETE api/posts/guid
        [Authorize]
        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeleteAsync(Guid postId)
        {
            await _postService.DeleteAsync(postId);
            return Ok();
        }
    }
}
