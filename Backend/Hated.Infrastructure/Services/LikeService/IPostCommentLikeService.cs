using System;
using System.Threading.Tasks;

namespace Hated.Infrastructure.Services.Like
{
    public interface IPostCommentLikeService : IService
    {
        Task LikePostCommentAsync(Guid postId, Guid commentId, Guid userId);
        Task DislikePostCommentAsync(Guid postId, Guid commentId, Guid userId);
    }
}
