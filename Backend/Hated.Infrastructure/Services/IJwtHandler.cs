using System;
using Hated.Infrastructure.DTO;

namespace Hated.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(string email, string role);
    }
}
