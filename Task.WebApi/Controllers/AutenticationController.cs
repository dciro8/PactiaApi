using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Models.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace Task.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticationController : ControllerBase
    {
        private readonly string secretKey;

        public AutenticationController(IConfiguration config)
        {
            secretKey= config.GetSection("settings").GetSection("secretkey").ToString();
        }
        [HttpPost]
        [Route("Validate")]
        public IActionResult Validate([FromBody] User request) {
            if (request.Email == "ciro@gmail.com" && request.Password == "123")
            {
                var KeyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Email));

                var tokeDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(KeyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenCofig = tokenHandler.CreateToken(tokeDescriptor);

                string createToken = tokenHandler.WriteToken(tokenCofig);

                return StatusCode(StatusCodes.Status200OK, new { token = createToken });
            }
            else
            { return StatusCode(StatusCodes.Status401Unauthorized, new { token = ""}); }
        }
    }
}
