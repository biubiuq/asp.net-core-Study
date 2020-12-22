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
    [Route("api/[controller]")]
   // [Authorize]   //表示需要认证授权访问
    [ApiController]
    public class BaseTypeController : ControllerBase
    {
        // GET: api/<BaseTypeController>
        public dbContext _context;
        public BaseTypeController(dbContext dbContext)
        {
            _context = dbContext;
        }
        [HttpGet]
        public IEnumerable<baseType> Get()
        {
            return _context.baseType.ToList();
        }

        // GET api/<BaseTypeController>/5
        [HttpGet("{type}")]
        public IEnumerable<baseType> Get(string type)
        {
            var  data= _context.baseType.Where(a=>a.type==type).ToList();
            return data;
        }

        // POST api/<BaseTypeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BaseTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BaseTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
