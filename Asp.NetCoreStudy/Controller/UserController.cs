using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetCoreStudy.db;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Study.Infrastructure.Page;
using Study.Model;
using Study.Model.Dto;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.NetCoreStudy.Controller
{
    [Authorize]   //表示需要认证授权访问
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
        [HttpGet("Page")]
        public PageResultDto<User> Get([FromQuery] UserDto user)
        {
            var result = new PageResultDto<User>();
            result.List=  _context.User.Where(a => a.userName == user.userName && a.passWord == user.passWord).Skip(user.PageSize* (user.PageIndex - 1)).Take(user.PageSize).ToList();
            result.PageIndex = user.PageIndex;
            result.PageSize = user.PageSize;
            result.TotalPages = _context.User.Where(a => a.userName == user.userName && a.passWord == user.passWord).Count();
            return result;
        }
    
        
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
