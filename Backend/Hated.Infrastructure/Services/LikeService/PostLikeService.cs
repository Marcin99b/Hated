using System;
using System.Threading.Tasks;
using Hated.Core.Repositories;

namespace Hated.Infrastructure.Services.Like
{
    public class PostLikeService : IPostLikeService
    {
        private readonly IPostRepository _postRepository;

        public PostLikeService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task LikePostAsync(string postId, Guid userId)
        {
            var post = await _postRepository.GetAsync(postId);
            post.AddLike(userId);
            await _postRepository.UpdateAsync(post);
        }

        public async Task DislikePostAsync(string postId, Guid userId)
        {
            var post = await _postRepository.GetAsync(postId);
            post.DeleteLike(userId);
            await _postRepository.UpdateAsync(post);
        }
    }
}
