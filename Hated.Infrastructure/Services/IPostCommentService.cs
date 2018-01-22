using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hated.Infrastructure.DTO;

namespace Hated.Infrastructure.Services
{
    public interface IPostCommentService
    {
        Task<Guid> AddAsync(Guid userId, Guid postId, string content);
        Task<CommentDto> GetAsync(Guid id);
        Task<IEnumerable<CommentDto>> GetAllFromPostAsync(Guid postId);
        Task<IEnumerable<CommentDto>> GetAllAsync();
        Task UpdateAsync(Guid postId, CommentDto updatedComment);
        Task DeleteAsync(Guid postId, Guid commentId);
    }
}
