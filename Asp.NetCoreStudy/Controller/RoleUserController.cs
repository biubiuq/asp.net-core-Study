using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Study.Model;
using Study.Repository.EFRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.NetCoreStudy.Controller
{
    [Authorize]   //表示需要认证授权访问
    [Route("api/[controller]")]
    [ApiController]
    public class RoleUserController : ControllerBase
    {
        public dbContext _context;
        public RoleUserController(dbContext dbContext)
        {
            _context = dbContext;
        }
        // GET: api/<RoleUserController>
        [HttpGet("id")]
        public IEnumerable<string> Get()
        {
            if (true)
            {
                
            }
            return new string[] { "value1", "value2" };
        }

        // GET api/<RoleUserController>/5
        [HttpGet("{id}")]
        public IEnumerable<role_user> Get(string id)
        {
            return _context.role_user.Where(a => a.UserId == id).ToList();
        }

        // POST api/<RoleUserController>
        [HttpPost]
        public void Post(string User_Id,string [] role_Id)
        {

        }

        // PUT api/<RoleUserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<RoleUserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
