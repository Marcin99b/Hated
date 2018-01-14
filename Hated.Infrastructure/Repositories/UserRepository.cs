using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hated.Core.Domain;
using Hated.Core.Repositories;

namespace Hated.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        //TODO this must be empty, defined data is exist only for tests
        private static readonly ISet<User> _users = new HashSet<User>
        {
            new User("user1@email.com", "user1", "secret"),
            new User("user2@email.com", "user2", "secret"),
            new User("user3@email.com", "user3", "secret"),
            new User("user4@email.com", "user4", "secret")
        };

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_users.Single(x => x.Email == email));

        public async Task<IEnumerable<User>> GetAllAsync()
            => await Task.FromResult(_users);

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            _users.Where(x => x.Id == user.Id).Select(x => user).ToHashSet();
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(User user)
        {
            _users.Remove(user);
            await Task.CompletedTask;
        }
    }
}

