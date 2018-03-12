using System;
using System.Threading.Tasks;

namespace Hated.Infrastructure.Services.Like
{
    public interface IPostLikeService : IService
    {
        Task LikePostAsync(int postId, Guid userId);
        Task DislikePostAsync(int postId, Guid userId);
    }
}
