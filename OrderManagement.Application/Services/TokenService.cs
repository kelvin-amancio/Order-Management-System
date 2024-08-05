using Microsoft.IdentityModel.Tokens;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Core.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace OrderManagement.Application.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(StringHelpers.TokenKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(8),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
