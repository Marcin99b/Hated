using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hated.Infrastructure.DTO;

namespace Hated.Infrastructure.Services
{
    public interface IPostCommentService : IService
    {
        Task<Guid> AddAsync(Guid userId, string postId, string content);
        Task<CommentDto> GetAsyncFromPost(string postId, Guid commentId);
        Task<IEnumerable<CommentDto>> GetAllFromPostAsync(string postId, int from, int number);
        Task UpdateAsync(string postId, CommentDto updatedComment);
        Task DeleteAsync(string postId, Guid commentId);
    }
}
