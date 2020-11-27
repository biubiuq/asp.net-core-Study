using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreStudy.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类
        public UserController(IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }

        [AllowAnonymous]  //表示可以匿名访问
        [HttpPost]
        public IActionResult Authenticate([FromBody] LoginViewModel loginViewModel)
        {
            var token = _jwtAuthenticationHandler.Authenticate(loginViewModel.UserName, loginViewModel.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [Authorize]   //表示需要认证授权访问
      
        [HttpGet]
        public List<object> List()
        {
            return new List<object>()
            {
                "user1","user2","user3","user..."
            };
        }
    }
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
