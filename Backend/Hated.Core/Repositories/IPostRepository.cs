using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hated.Core.Domain;

namespace Hated.Core.Repositories
{
    public interface IPostRepository : IRepository
    {
        Task<Post> GetAsync(string id);

        Task<IEnumerable<Post>> GetAllAsync(int from, int number);

        Task AddAsync(Post post);

        Task UpdateAsync(Post post);

        Task RemoveAsync(Post post);
    }
}
