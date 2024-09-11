using detaInterview.Models;
using detaInterview.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace detaInterview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : Controller
    {
        private readonly IConfiguration _config;
        public AuthenticateController(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            if (login.id == "exam" && login.password == "exam")
            {
                var token = JwtTokenHelper.GenerateJwtToken(
                    id: login.id,
                    key: _config["Jwt:Key"],
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    expiresInMinutes: 30
                );
                return Ok(new { token });
            }

            return Unauthorized();
        }

        /// <summary>
        /// 驗證Token
        /// </summary>
        /// <returns></returns>
        /// 
        [Authorize]
        [HttpGet]
        public IActionResult ValidateToken()
        {
            var authHeader = Request.Headers["Authorization"].ToString();

            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var token = authHeader.Substring("Bearer ".Length).Trim();

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

                try
                {
                    // 驗證 Token
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = _config["Jwt:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = _config["Jwt:Audience"],
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    // 如果 Token 有效，提取到期時間
                    var jwtToken = (JwtSecurityToken)validatedToken;
                    var expiration = jwtToken.ValidTo;

                    return Ok(new
                    {
                        message = "Token 驗證成功.",
                        expiresAt = expiration.ToString("yyyy-MM-ddTHH:mm")
                    });
                }
                catch (Exception ex)
                {
                    // 捕捉任何驗證失敗的情況
                    return Unauthorized(new { message = "驗證失敗", error = ex.Message });
                }
            }

            return BadRequest(new { message = "驗證沒有通過" });
        }
    }
}
