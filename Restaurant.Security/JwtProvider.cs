using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Restaurant.Security
{
    public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
    {
        private readonly JwtOptions _options = options.Value;

        public string Generate(UserModel user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Role, user.Role),     
                new(ClaimTypes.NameIdentifier, user.Id.ToString())    
            };

            var signingCredentials = new SigningCredentials(

                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)), 

                    SecurityAlgorithms.HmacSha256
                );

            var token = new JwtSecurityToken(

                    claims: claims,

                    signingCredentials: signingCredentials,

                    expires: DateTime.UtcNow.AddHours(_options.ExpiresHours)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }

    public class JwtOptions
    {
        public string SecretKey { get; set; } = string.Empty;
        public int ExpiresHours {  get; set; }
    }
}
