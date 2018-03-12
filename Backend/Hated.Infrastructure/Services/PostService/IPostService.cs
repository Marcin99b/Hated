using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hated.Infrastructure.DTO;

namespace Hated.Infrastructure.Services.PostService
{
    public interface IPostService : IService
    {
        Task<Guid> AddAsync(Guid userId, string content);
        Task<DetailPostDto> GetAsync(Guid id, int commentsFrom, int commentsNumber);
        Task<IEnumerable<PostDto>> GetAllAsync(int from, int number);
        Task UpdateAsync(Guid postId, string content);
        Task UpdateByAdminAsync(Guid postId, string content, Guid adminId, string comment);
        Task DeleteAsync(Guid id);
    }
}
