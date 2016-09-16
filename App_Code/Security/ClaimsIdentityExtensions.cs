using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

/// <summary>
/// Summary description for ClaimsIdentityExtensions
/// </summary>
public static class ClaimsIdentityExtensions
{
    public static Guid GetUserId(this IIdentity identity)
    {
        return GetClaimsValue(identity, ClaimTypes.Hash);
    }

    private static Guid GetClaimsValue(IIdentity identity, string claimType)
    {
        if (identity is ClaimsIdentity)
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)identity;
            Claim userIdClaim = claimsIdentity.FindFirst(claimType);
            if (userIdClaim != null)
            {
                return Guid.Parse(userIdClaim.Value);
            }
            else
            {
                throw new SecurityException(string.Format("Identity is missing value for claim type {0}", claimType));
            }
        }
        else
        {
            throw new SecurityException("Identity is not a valid Claims Identity");
        }
    }
}