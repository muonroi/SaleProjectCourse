using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WebSaleRepository.DTO.Accounts;
using WebSaleRepository.Responses.Accounts;

namespace WebSaleRepository.Helper
{
    public static class ManagerTokenHelper
    {
        public static string GenarateToken(IConfiguration configuration, AccountDTO accountInfo, int timeExpires)
        {
            IConfigurationSection jwtSettings = configuration.GetSection("JWT");
            byte[] jwtKey = Encoding.UTF8.GetBytes(jwtSettings.GetSection("Secret").Value);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, accountInfo.Username),
                    new Claim(ClaimTypes.Role, accountInfo.RoleName)
                }),
                Expires = DateTime.UtcNow.AddHours(timeExpires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtKey), SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string result = tokenHandler.WriteToken(token);
            return result;
        }

        private static JwtSecurityToken PareseJwtToken(IConfiguration configuration, string token)
        {
            IConfigurationSection jwtSettings = configuration.GetSection("JWT");
            byte[] jwtKey = Encoding.UTF8.GetBytes(jwtSettings.GetSection("Secret").Value);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = jwtKey;
            try
            {
                _ = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
            }
            catch
            {
            }
            finally
            {
            }
            JwtSecurityToken result = tokenHandler.ReadToken(token) as JwtSecurityToken;
            return result;
        }

        public static TokenInfo GetTokenInfo(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            string token = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            JwtSecurityToken tokenRaw = PareseJwtToken(configuration, token);
            TokenInfo result = new TokenInfo
            {
                UserName = tokenRaw.Claims.FirstOrDefault(claim => claim.Type == "nameid")?.Value,
                Role = tokenRaw.Claims.FirstOrDefault(claim => claim.Type == "role")?.Value
            };
            return result;
        }
    }
}