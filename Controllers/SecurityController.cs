using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private string GenerateJSONWebToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Jobin@12345Jobin789"));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Issuer","Jobin"),
                new Claim("Admin","true"),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.UniqueName,username)
            };

            var token = new JwtSecurityToken("Jobin",
                "Jobin",
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet]
        public string Get()
        {
            return GenerateJSONWebToken("Jobin");
        }
    }
}
