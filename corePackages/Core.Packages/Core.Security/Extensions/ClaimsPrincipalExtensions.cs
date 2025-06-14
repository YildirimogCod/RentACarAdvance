﻿using System.Security.Claims;

namespace Core.Security.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result ?? new List<string>();
        }
        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims(ClaimTypes.Role);
        }

        public static int GetUserId(this ClaimsPrincipal claimPrincipal) =>
            Convert.ToInt32(claimPrincipal?.Claims(ClaimTypes.NameIdentifier)?.FirstOrDefault());
    }
}
