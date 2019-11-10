using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CardGames.Application.Interfaces.Infrastructure.Authentication.Models;
using CardGames.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CardGames.Web.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly UserManager<Player> _userManager;

        public AuthenticationController(UserManager<Player> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !_userManager.CheckPasswordAsync(user, model.Password).Result)
            {
                return Unauthorized();
            }

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));

            var token = new JwtSecurityToken(
                issuer:"http://khoa-cardgames.com",
                audience: "http://khoa-cardgames.com",
                expires:DateTime.UtcNow.AddMinutes(5),
                signingCredentials:new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                claims:claims
                );

            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            });
        }
    }
}
