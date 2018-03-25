using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hated.Infrastructure.DTO;

namespace Hated.Infrastructure.Services.PostService
{
    public interface IPostService : IService
    {
        Task<string> AddAsync(Guid userId, string title, string content);
        Task<DetailPostDto> GetAsync(string id, int commentsFrom, int commentsNumber);
        Task<IEnumerable<PostDto>> GetAllAsync(int from, int number);
        Task UpdateAsync(string postId, string title, string content);
        Task UpdateByAdminAsync(string postId, string title, string content, Guid adminId, string comment);
        Task DeleteAsync(string id);
    }
}
