using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hated.Core.Domain;
using Hated.Core.Repositories;
using Hated.Infrastructure.Extensions;
using MongoDB.Driver;

namespace Hated.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _mongoDatabase;
        private IMongoCollection<User> _users => _mongoDatabase.GetCollection<User>("Users");

        public UserRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_users.AsQueryable().SingleOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_users.AsQueryable().SingleOrDefault(x => x.Email == email));

        public async Task<IEnumerable<User>> GetAllAsync()
            => await _users.AsQueryable().ToListAsync();

        public async Task<IEnumerable<User>> GetAllAsync(int from, int number)
            => await _users.PaginateMongo(from, number);

        public async Task AddAsync(User user)
            => await _users.InsertOneAsync(user);

        public async Task UpdateAsync(User user)
            => await _users.ReplaceOneAsync(x => x.Id == user.Id, user);

        public async Task RemoveAsync(User user)
            => await _users.DeleteOneAsync(x => x.Id == user.Id);

    }
}

