using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetCoreStudy.db;
using Asp.NetCoreStudy.jwt;
using Microsoft.AspNetCore.Mvc;
using Study.Model;

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
            User user1 = _user.GetSingerAsync(a => a.userName == user.userName && a.passWord == user.passWord);
            if (user1 == null)
            {
                return NotFound();
            }
           return _jwt.Authenticate(user1.userName, user1.passWord);
        }

       
    }
}
