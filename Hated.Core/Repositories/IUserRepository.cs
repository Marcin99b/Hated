using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hated.Core.Domain;

namespace Hated.Core.Repositories
{
    interface IUserRepository
    {
        Task<User> GetAsync(Guid id);

        Task<User> GetAsync(string email);

        Task<IEnumerable<User>> GetAllAsync();

        Task AddAsync(User user);

        Task UpdateAsync(User user);

        Task RemoveAsync(Guid id);
    }
}
