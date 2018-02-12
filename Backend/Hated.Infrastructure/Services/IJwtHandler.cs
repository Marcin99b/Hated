using System;
using System.Security.Claims;
using Hated.Infrastructure.DTO;

namespace Hated.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string role);
        JwtDto RefreshToken(ClaimsPrincipal userToken);
    }
}
