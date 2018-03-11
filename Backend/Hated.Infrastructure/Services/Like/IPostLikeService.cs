using System;
using System.Threading.Tasks;

namespace Hated.Infrastructure.Services.Like
{
    public interface IPostLikeService : IService
    {
        Task LikePostAsync(Guid postId, Guid userId);
        Task DislikePostAsync(Guid postId, Guid userId);
    }
}
