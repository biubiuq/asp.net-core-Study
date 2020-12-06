using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetCoreStudy.db;
using Microsoft.AspNetCore.Mvc;
using Study.Model;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.NetCoreStudy.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public mysqlContext _context;
        public UserController(mysqlContext dbContext)
        {
            _context = dbContext;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.User.ToList();
        }
        [HttpGet]
        public User Get([FromBody] User user)
        {
          return  _context.User.Where(a =>  a.userName == user.userName && a.passWord == user.passWord ).SingleOrDefault() ;
        }
        // GET api/<UserController>/5
     

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
