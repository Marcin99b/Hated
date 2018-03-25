﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Hated.Core.Repositories;

namespace Hated.Infrastructure.Services.Like
{
    public class PostCommentLikeService : IPostCommentLikeService
    {
        private readonly IPostRepository _postRepository;

        public PostCommentLikeService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task LikePostCommentAsync(Guid postId, Guid commentId, Guid userId)
        {
            var post = await _postRepository.GetAsync(postId);
            var comment = post.Comments.FirstOrDefault(x => x.Id == commentId);
            comment?.AddLike(userId);
            post.UpdateComment(comment);
            await _postRepository.UpdateAsync(post);
        }

        public async Task DislikePostCommentAsync(Guid postId, Guid commentId, Guid userId)
        {
            var post = await _postRepository.GetAsync(postId);
            var comment = post.Comments.FirstOrDefault(x => x.Id == commentId);
            comment?.DeleteLike(userId);
            post.UpdateComment(comment);
            await _postRepository.UpdateAsync(post);
        }
    }
}
