using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hated.Infrastructure.DTO;

namespace Hated.Infrastructure.Services.PostService
{
    public interface IPostService : IService
    {
        Task<int> AddAsync(Guid userId, string title, string content);
        Task<DetailPostDto> GetAsync(int id, int commentsFrom, int commentsNumber);
        Task<IEnumerable<PostDto>> GetAllAsync(int from, int number);
        Task UpdateAsync(int postId, string title, string content);
        Task UpdateByAdminAsync(int postId, string title, string content, Guid adminId, string comment);
        Task DeleteAsync(int id);
    }
}
