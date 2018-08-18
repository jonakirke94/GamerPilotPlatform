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

namespace gamerpilotPlatform.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly GamerpilotVodContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;
        public AccountController(GamerpilotVodContext context, IPasswordHasher passwordHasher, ITokenService tokenService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Signup([FromBody] User sentUser)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == sentUser.Email);
            if (user != null) return StatusCode(409, Json(sentUser.Email + " already exists."));

            var usersClaims = new[]
            {
                new Claim(ClaimTypes.Name, sentUser.Username),
            };

            var jwtToken = _tokenService.GenerateAccessToken(usersClaims);
            var refreshToken = _tokenService.GenerateRefreshToken();
         
            try
            {
                _context.Users.Add(new User
                {
                    RefreshToken = refreshToken,
                    Username = sentUser.Username,
                    Email = sentUser.Email,
                    Password = _passwordHasher.GenerateIdentityV3Hash(sentUser.Password)
                });

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return new ObjectResult(new
            {
                token = jwtToken,
                refreshToken = refreshToken
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
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var jwtToken = _tokenService.GenerateAccessToken(usersClaims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            await _context.SaveChangesAsync();

            return new ObjectResult(new
            {
                token = jwtToken,
                refreshToken = refreshToken
            });
        }
    }
}