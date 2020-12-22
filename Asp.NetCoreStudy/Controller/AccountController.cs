using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetCoreStudy.db;
using Asp.NetCoreStudy.jwt;
using Microsoft.AspNetCore.Mvc;
using Study.Model;
using Study.Repository.EFRepository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.NetCoreStudy.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public dbContext _context;
        private IJwtAuthenticationHandler _jwt;
        public AccountController(IJwtAuthenticationHandler jwt, dbContext dbContext)
        {
            _context = dbContext;
               _jwt = jwt;

        }
        // GET api/<AccountController>/5
        [HttpPost]
        public dynamic Post( User user)
        {
            var user1 = _context.User.Where(a => a.userName == user.userName && a.passWord == user.passWord).SingleOrDefault();
            if (user1 == null)
            {
                return NotFound();
            }
           return _jwt.Authenticate(user.userName, user.passWord);
        }

       
    }
}
