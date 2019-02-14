using Domain.ValueObjects;
using System;
using System.Linq;
using System.Security.Claims;

namespace Cx.AccessControl.Application.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        private const int FALLBACK_USER_ID = -1;

        public static int GetUserId(this ClaimsPrincipal principalUser)
        {
            int userId = principalUser.Claims.Where(c => c.Type == ClaimTypes.Name)
                .Select(c => Convert.ToInt32(c.Value))
                .FirstOrDefault();
            return userId == default(int) ? FALLBACK_USER_ID : userId;
        }

        public static string GetUserEmail(this ClaimsPrincipal principalUser)
        {
            var email = principalUser.Claims.Where(c => c.Type == CustomClaimTypes.Email)
                .Select(c => c.Value)
                .FirstOrDefault();

            return email;
        }

        public static string GetUserName(this ClaimsPrincipal principalUser)
        {
            var username = principalUser.Claims.Where(c => c.Type == CustomClaimTypes.UserName)
                .Select(c => c.Value)
                .FirstOrDefault();

            return username;
        }

    }
}
