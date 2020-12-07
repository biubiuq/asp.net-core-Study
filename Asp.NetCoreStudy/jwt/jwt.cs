using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetCoreStudy.jwt
{
    public interface IJwtAuthenticationHandler
    {
        string Authenticate(string username, string password);
    }
    public class JwtAuthenticationHandler : IJwtAuthenticationHandler
    {
    

        private readonly string _token;   //声明一个加密的密钥，由外部传入

        public JwtAuthenticationHandler(string token)
        {
            _token = token;
        }

        public string Authenticate(string username, string password)
        {
            //如果用户名密码错误则返回null
         
            var tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_token));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                SigningCredentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256),
                Expires = DateTime.Now.AddMinutes(10),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,username),
                })
            };

            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
