using System;
using System.Threading.Tasks;

namespace Hated.Infrastructure.Services
{
    public interface IActivationService : IService
    {
        Task ActivatePost(int postId);
        Task DeactivatePost(int postId);
    }
}
