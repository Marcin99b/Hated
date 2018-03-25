using System;
using System.Threading.Tasks;

namespace Hated.Infrastructure.Services.Like
{
    public interface IPostCommentLikeService : IService
    {
        Task LikePostCommentAsync(string postId, Guid commentId, Guid userId);
        Task DislikePostCommentAsync(string postId, Guid commentId, Guid userId);
    }
}
