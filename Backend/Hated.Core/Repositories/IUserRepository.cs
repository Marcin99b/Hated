using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hated.Core.Domain;

namespace Hated.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetAsync(Guid id);

        Task<User> GetAsync(string email = null, string username = null);

        Task<IEnumerable<User>> GetAllAsync(int from, int number);

        Task AddAsync(User user);

        Task UpdateAsync(User user);

        Task RemoveAsync(User user);
    }
}
