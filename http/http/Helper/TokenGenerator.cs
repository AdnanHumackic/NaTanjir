using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace http.Helper
{
    public class TokenGenerator
    {
        public static string Generate()
        {
            byte[] key = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "subject"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken
                (
                    issuer: "natanjir",
                    audience: "natanjir",
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(90),
                    signingCredentials: credentials
                );
            var jwtHandler = new JwtSecurityTokenHandler();
            return jwtHandler.WriteToken(token);

        }
    }
}
