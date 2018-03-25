using System;
using System.Threading.Tasks;

namespace Hated.Infrastructure.Services.Like
{
    public interface IPostLikeService : IService
    {
        Task LikePostAsync(string postId, Guid userId);
        Task DislikePostAsync(string postId, Guid userId);
    }
}
