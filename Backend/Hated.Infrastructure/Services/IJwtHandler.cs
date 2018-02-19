using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Hated.Infrastructure.DTO;

namespace Hated.Infrastructure.Services
{
    public interface IJwtHandler
    {
        Task<JwtDto> CreateToken(Guid userId, string role);
        Task<JwtDto> RefreshToken(ClaimsPrincipal userToken);
    }
}
