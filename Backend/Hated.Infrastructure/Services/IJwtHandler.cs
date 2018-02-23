using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Hated.Infrastructure.DTO;

namespace Hated.Infrastructure.Services
{
    public interface IJwtHandler
    {
        Task<JwtDto> CreateTokenAsync(Guid userId, string role);
        Task<JwtDto> CreateTokenByUserObject(UserDto user);
        Task<JwtDto> RefreshTokenAsync(ClaimsPrincipal userToken);
    }
}
