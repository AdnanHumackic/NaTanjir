using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace http.Helper
{
    public class TokenGenerator
    {
        public static string Generate()
        {
            var key=Guid.NewGuid().ToByteArray();
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
