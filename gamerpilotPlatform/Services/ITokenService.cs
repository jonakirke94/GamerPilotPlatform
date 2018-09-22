using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<System.Security.Claims.Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        Boolean Validate(string jwt);
        string getClaimsId(string token);
    }
}
