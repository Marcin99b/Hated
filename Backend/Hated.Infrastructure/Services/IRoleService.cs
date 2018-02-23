using System;
using System.Threading.Tasks;

namespace Hated.Infrastructure.Services
{
    public interface IRoleService : IService
    {
        Task SetAdmin(Guid id);
        Task SetUser(Guid id);
    }
}
