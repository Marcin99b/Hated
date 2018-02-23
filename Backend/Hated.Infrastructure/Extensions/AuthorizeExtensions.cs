using System;
using System.Security.Claims;

namespace Hated.Infrastructure.Extensions
{
    public static class AuthorizeExtensions
    {
        public static bool HavePermissions(this Guid id, ClaimsPrincipal userToken)
            => userToken.IsAdmin() || id.IsAuthor(userToken);

        public static bool IsAdmin(this ClaimsPrincipal userToken)
            => userToken.FindFirst(ClaimTypes.Role).Value == "admin";

        public static bool IsAuthor(this Guid id, ClaimsPrincipal userToken)
            => userToken.FindFirst(ClaimTypes.NameIdentifier).Value == id.ToString();
    }
}
