using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using gamerpilotPlatform.Data;
using gamerpilotPlatform.Model;
using gamerpilotPlatform.Services;
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
            var user = _context.Users.SingleOrDefault(u => u.Username == sentUser.Username);
            if (user != null) return StatusCode(409);

            _context.Users.Add(new User
            {
                Username = sentUser.Username,
                Password = _passwordHasher.GenerateIdentityV3Hash(sentUser.Password)
            });


            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] User sentUser)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == sentUser.Username);
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