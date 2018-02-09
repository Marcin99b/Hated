using System;
using System.Security.Claims;

namespace Hated.Infrastructure.Extensions
{
    public static class AuthorizeExtensions
    {
        public static bool IsAuthorOrAdmin(this Guid id, ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value == id.ToString();
        }
    }
}
