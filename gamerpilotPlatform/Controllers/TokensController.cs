using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamerpilotPlatform.Data;
using gamerpilotPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace gamerpilotPlatform.Controllers
{
    [Route("api/[controller]")]
    public class TokensController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly GamerpilotVodContext _context;
        private readonly ILogger<TokensController> _log;

        public TokensController(ITokenService tokenService, GamerpilotVodContext context, ILogger<TokensController> log)
        {
            _tokenService = tokenService;
            _context = context;
            _log = log;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Refresh([FromBody]JObject data)
        {
            var token = data["token"].ToString();
            var refreshToken = data["refreshToken"].ToString();

            var principal = _tokenService.GetPrincipalFromExpiredToken(token);
            var username = principal.Identity.Name; //this is mapped to the Name claim by default

            var user = _context.Users.SingleOrDefault(u => u.Username == username);

            //if the user wasn't found or matched the users refresh token the users needs to re-authenticate
            if (user == null || user.RefreshToken != refreshToken) return BadRequest();

            //if the refresh token has expired the user needs to re-authenticate
            if (!_tokenService.Validate(refreshToken)) return BadRequest();

            var newJwtToken = _tokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _context.SaveChangesAsync();
            _log.LogInformation($"Saved new refreshToken for user {user.Id}");

            return new ObjectResult(new
            {
                token = newJwtToken,
                refreshToken = newRefreshToken
            });
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Revoke()
        {
            //var username = User.Identity.Name;

            //var user = _context.Users.SingleOrDefault(u => u.Username == username);
            //if (user == null) return BadRequest();

            //user.RefreshToken = null;

            //await _context.SaveChangesAsync();
            //_log.LogInformation($"Saved new refreshToken for user {user.Id}");

            //return NoContent();
        }

    }
}