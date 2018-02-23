using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Hated.Infrastructure.DTO;
using Hated.Infrastructure.Extensions;
using Hated.Infrastructure.Settings;
using Microsoft.IdentityModel.Tokens;

namespace Hated.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _jwtSettings;

        public JwtHandler(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public async Task<JwtDto> CreateTokenAsync(Guid userId, string role)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()), 
                new Claim(ClaimTypes.Role, role), 
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), 
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString(), ClaimValueTypes.Integer64)
            };
            var signingCredentials = await Task.FromResult(new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)), 
                SecurityAlgorithms.HmacSha256));
            var expires = now.AddMinutes(_jwtSettings.ExpiryMinutes);
            var jwt = await Task.FromResult(new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
                ));
            var token = await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(jwt));
            return new JwtDto
            {
                Token = token,
                Expiry = expires.ToTimestamp()
            };
        }

        public async Task<JwtDto> CreateTokenByUserObject(UserDto user)
            => await CreateTokenAsync(user.Id, user.Role);

        public async Task<JwtDto> RefreshTokenAsync(ClaimsPrincipal userToken)
        {
            var userId = Guid.Parse(userToken.FindFirst(ClaimTypes.NameIdentifier).Value);
            var role = userToken.FindFirst(ClaimTypes.Role).Value;
            return await CreateTokenAsync(userId, role);
        }
    }
}
