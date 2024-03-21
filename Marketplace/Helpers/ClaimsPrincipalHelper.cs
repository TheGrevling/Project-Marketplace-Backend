﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Claims;
namespace Marketplace.Helpers
{
    public static class ClaimsPrincipalHelper
    {
        public static string UserId(this ClaimsPrincipal user)
        {
            IEnumerable<Claim> claims = user.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier);
            return claims.Count() >= 2 ? claims.ElementAt(1).Value : null;

        }
        public static string? Email(this ClaimsPrincipal user)
        {
            Claim? claim = user.FindFirst(ClaimTypes.Email);
            return claim?.Value;
        }
        
        public static string? UserName(this ClaimsPrincipal user)
        {
            Claim? claim = user.FindFirst(ClaimTypes.Name);
            return claim?.Value;
        }
    }
}
