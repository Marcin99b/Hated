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
    public class PostRepository : IPostRepository
    {
        private readonly IMongoDatabase _mongoDatabase;
        private IMongoCollection<Post> _posts => _mongoDatabase.GetCollection<Post>("Posts");

        public PostRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task<Post> GetAsync(Guid id)
            => await Task.FromResult(_posts.AsQueryable().SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Post>> GetAllAsync()
            => await _posts.AsQueryable().ToListAsync() as IEnumerable<Post>;

        public async Task<IEnumerable<Post>> GetAllAsync(int from, int number)
            => await _posts.PaginateMongo(from, number);

        public async Task AddAsync(Post post)
            => await _posts.InsertOneAsync(post);

        public async Task UpdateAsync(Post post)
            => await _posts.ReplaceOneAsync(x => x.Id == post.Id, post);

        public async Task RemoveAsync(Post post)
            => await _posts.DeleteOneAsync(x => x.Id == post.Id);
    }
}
