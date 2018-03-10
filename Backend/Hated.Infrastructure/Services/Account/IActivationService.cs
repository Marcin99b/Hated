using System;
using System.Threading.Tasks;

namespace Hated.Infrastructure.Services
{
    public interface IActivationService : IService
    {
        Task ActivatePost(Guid postId);
        Task DeactivatePost(Guid postId);
    }
}
