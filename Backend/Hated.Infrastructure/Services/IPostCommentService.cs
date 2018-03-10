using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hated.Infrastructure.DTO;

namespace Hated.Infrastructure.Services
{
    public interface IPostCommentService : IService
    {
        Task<Guid> AddAsync(Guid userId, Guid postId, string content);
        Task<CommentDto> GetAsyncFromPost(Guid postId, Guid commentId);
        Task<IEnumerable<CommentDto>> GetAllFromPostAsync(Guid postId, int from, int number);
        Task UpdateAsync(Guid postId, CommentDto updatedComment);
        Task DeleteAsync(Guid postId, Guid commentId);
    }
}
