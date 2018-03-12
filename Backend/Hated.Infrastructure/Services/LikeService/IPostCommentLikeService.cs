using System;
using System.Threading.Tasks;

namespace Hated.Infrastructure.Services.Like
{
    public interface IPostCommentLikeService : IService
    {
        Task LikePostCommentAsync(int postId, Guid commentId, Guid userId);
        Task DislikePostCommentAsync(int postId, Guid commentId, Guid userId);
    }
}
