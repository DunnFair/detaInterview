using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace detaInterview.Utils
{
    public static class JwtTokenHelper
    {
        public static string GenerateJwtToken(string id, string key, string issuer, string audience, int expiresInMinutes)
        {
            // 使用對稱密鑰來簽名 Token
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // 建立 Claims (可根據需要添加更多 claims)
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            // 創建 JWT Token
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(expiresInMinutes),
                signingCredentials: credentials);

            // 返回產生的 JWT Token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
