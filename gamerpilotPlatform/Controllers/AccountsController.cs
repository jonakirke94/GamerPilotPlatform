using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using gamerpilotPlatform.Data;
using gamerpilotPlatform.Model;
using gamerpilotPlatform.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace gamerpilotPlatform.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly GamerpilotVodContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AccountsController> _log;

        public AccountsController(GamerpilotVodContext context, IPasswordHasher passwordHasher, ITokenService tokenService, ILogger<AccountsController> log)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _log = log;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Signup([FromBody] User sentUser)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == sentUser.Email);
            if (user != null) return StatusCode(409, Json(sentUser.Email + " already exists."));

                    var refreshToken = _tokenService.GenerateRefreshToken();
            var pass = _passwordHasher.GenerateIdentityV3Hash(sentUser.Password);
            var jwtToken = string.Empty;

            try
            {
                var newUser = new User
                {
                    RefreshToken = refreshToken,
                    Username = sentUser.Username,
                    Email = sentUser.Email,
                    Password = pass
                };

                // add to DB
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                _log.LogInformation($"New user was created {user.Id}");

                //access Id of newly inserted entity
                var usersClaims = new[]
                {
                    new Claim(ClaimTypes.Name, newUser.Username),
                    new Claim("UserId", newUser.Id)
                };


                jwtToken = _tokenService.GenerateAccessToken(usersClaims);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return new ObjectResult(new
            {
                token = jwtToken,
                refreshToken
            });
 
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] User sentUser)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == sentUser.Email);
            if (user == null || !_passwordHasher.VerifyIdentityV3Hash(sentUser.Password, user.Password)) return BadRequest();

            var usersClaims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("UserId", user.Id)
            };

            var jwtToken = _tokenService.GenerateAccessToken(usersClaims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            await _context.SaveChangesAsync();
            _log.LogInformation($"Saved new refreshtoken for {user.Id}");

            return new ObjectResult(new
            {
                token = jwtToken,
                refreshToken = refreshToken
            });
        }
    }
}