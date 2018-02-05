using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hated.Core.Domain;
using Hated.Core.Repositories;

namespace Hated.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private static readonly ISet<Post> _posts = new HashSet<Post>();

        public async Task<Post> GetAsync(Guid id)
            => await Task.FromResult(_posts.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Post>> GetAllAsync()
            => await Task.FromResult(_posts);

        public async Task AddAsync(Post post)
        {
            _posts.Add(post);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Post post)
        {
            _posts.Where(x => x.Id == post.Id).Select(x => post).ToHashSet();
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(Post post)
        {
            _posts.Remove(post);
            await Task.CompletedTask;
        }
    }
}
