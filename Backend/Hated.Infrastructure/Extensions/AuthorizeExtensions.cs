using System;
using System.Security.Claims;

namespace Hated.Infrastructure.Extensions
{
    public static class AuthorizeExtensions
    {
        public static bool IsAuthorOrAdmin(this Guid id, ClaimsPrincipal userToken)
        {
            var isAdmin = userToken.FindFirst(ClaimTypes.Role).Value == "admin";
            var isAuthor = userToken.FindFirst(ClaimTypes.NameIdentifier).Value == id.ToString();
            return isAdmin || isAuthor;
        }
    }
}
