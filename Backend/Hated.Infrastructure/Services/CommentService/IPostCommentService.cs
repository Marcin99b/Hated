using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hated.Infrastructure.DTO;

namespace Hated.Infrastructure.Services
{
    public interface IPostCommentService : IService
    {
        Task<Guid> AddAsync(Guid userId, int postId, string content);
        Task<CommentDto> GetAsyncFromPost(int postId, Guid commentId);
        Task<IEnumerable<CommentDto>> GetAllFromPostAsync(int postId, int from, int number);
        Task UpdateAsync(int postId, CommentDto updatedComment);
        Task DeleteAsync(int postId, Guid commentId);
    }
}
