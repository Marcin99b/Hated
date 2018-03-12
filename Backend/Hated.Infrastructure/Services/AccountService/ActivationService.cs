using System;
using System.Threading.Tasks;
using Hated.Core.Repositories;

namespace Hated.Infrastructure.Services
{
    public class ActivationService : IActivationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;

        public ActivationService(IUserRepository userRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public async Task ActivatePost(Guid postId)
        {
            var post = await _postRepository.GetAsync(postId);
            post.Activate();
            await _postRepository.UpdateAsync(post);
        }

        public async Task DeactivatePost(Guid postId)
        {
            var post = await _postRepository.GetAsync(postId);
            post.Deactivate();
            await _postRepository.UpdateAsync(post);
        }
    }
}
