using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Study.Repository.EFRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.NetCoreStudy.Controller
{
    [Authorize]   //表示需要认证授权访问
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public dbContext _context;
        public RoleController(dbContext dbContext)
        {
            _context = dbContext;
        }
        // GET: api/<RoleController>
        [HttpGet("Id")]
        public IEnumerable<string> Get(string Id)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RoleController>/5
        [HttpGet()]
        public IEnumerable<dynamic> Get()
        {
          return  _context.Role.ToList();
        }

        // POST api/<RoleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
