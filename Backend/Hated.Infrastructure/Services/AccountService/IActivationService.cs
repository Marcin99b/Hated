using System;
using System.Threading.Tasks;

namespace Hated.Infrastructure.Services
{
    public interface IActivationService : IService
    {
        Task ActivatePost(string postId);
        Task DeactivatePost(string postId);
    }
}
