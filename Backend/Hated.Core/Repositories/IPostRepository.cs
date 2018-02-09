using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hated.Core.Domain;

namespace Hated.Core.Repositories
{
    public interface IPostRepository : IRepository
    {
        Task<Post> GetAsync(Guid id);

        Task<IEnumerable<Post>> GetAllAsync();

        Task AddAsync(Post post);

        Task UpdateAsync(Post post);

        Task RemoveAsync(Post post);
    }
}
