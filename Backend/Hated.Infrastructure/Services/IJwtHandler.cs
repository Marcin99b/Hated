using System;
using Hated.Infrastructure.DTO;

namespace Hated.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}
