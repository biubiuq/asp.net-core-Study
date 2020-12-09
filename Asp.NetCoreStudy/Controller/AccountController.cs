using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetCoreStudy.db;
using Asp.NetCoreStudy.jwt;
using Microsoft.AspNetCore.Mvc;
using Study.Model;
using Study.Model.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.NetCoreStudy.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserController _user;
        private IJwtAuthenticationHandler _jwt;
        public AccountController(IJwtAuthenticationHandler jwt, mysqlContext dbContext)
        {
            _user = new UserController(dbContext);
            _jwt = jwt;

        }
        // GET api/<AccountController>/5
        [HttpPost]
        public dynamic Post( User user)
        {
            var user1 = _user.Get(new UserDto() { 
                 userName=user.userName,
                  passWord=user.passWord
            });
            if (user1.List == null)
            {
                return NotFound();
            }
           return _jwt.Authenticate(user.userName, user.passWord);
        }

       
    }
}
