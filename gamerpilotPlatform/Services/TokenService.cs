using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace gamerpilotPlatform.Services
{

   public class TokenService : ITokenService
        {
            private readonly IConfiguration _configuration;

            public TokenService(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            //Generate access token which will be sent with each authorized request by the client
            public string GenerateAccessToken(IEnumerable<Claim> claims)
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["serverSigningPassword"]));

                var jwtToken = new JwtSecurityToken(
                    issuer: "Blinkingcaret",
                    audience: "Anyone",
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddMinutes(int.Parse(_configuration["accessTokenDurationInMinutes"])),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

                return new JwtSecurityTokenHandler().WriteToken(jwtToken); ;
            }

            //Generate refresh token which will later be used to refresh the access token
            public string GenerateRefreshToken()
            {
                //var randomNumber = new byte[32];
                //using (var rng = RandomNumberGenerator.Create())
                //{
                //    rng.GetBytes(randomNumber);
                //    return Convert.ToBase64String(randomNumber);
                //}
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["serverSigningPassword"]));

                var jwtToken = new JwtSecurityToken(
                    issuer: "Blinkingcaret",
                    audience: "Anyone",
                    expires: DateTime.UtcNow.AddMinutes(int.Parse(_configuration["refreshTokenDurationInMinutes"])),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

                return new JwtSecurityTokenHandler().WriteToken(jwtToken); ;
            }

    

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["serverSigningPassword"])),
                    ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
                var jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Invalid token");

                return principal;
            }

        public Boolean Validate(string jwt)
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["serverSigningPassword"])),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero //the default for this setting is 5 minutes
            };

            try
            {
                var claimsPrincipal = new JwtSecurityTokenHandler()
                    .ValidateToken(jwt, validationParameters, out var rawValidatedToken);

                return true;
                //return (JwtSecurityToken)rawValidatedToken;
                // Or, you can return the ClaimsPrincipal
                // (which has the JWT properties automatically mapped to .NET claims)
            }
            catch (SecurityTokenValidationException stvex)
            {
                // The token failed validation!
                // TODO: Log it or display an error.
                // throw new Exception($"Token failed validation: {stvex.Message}");
                return false;
            }
            catch (ArgumentException argex)
            {
                // The token was not well-formed or was invalid for some other reason.
                // TODO: Log it or display an error.
                // throw new Exception($"Token was invalid: {argex.Message}");
                return false;
            }
        }

        public string getClaimsId(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            //token sent as "Bearer xxxx"
  

            try
            {
                var tokenArr = token.Split(" ");
                var accessToken = tokenArr[1];
                var tokenS = handler.ReadToken(accessToken) as JwtSecurityToken;
                return tokenS.Claims.First(claim => claim.Type == "UserId").Value;
            }
            catch (Exception)
            {
                return null;
            }

        }


    }

}
