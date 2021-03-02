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
       
     

        // GET api/<RoleUserController>/5
        [HttpGet]
        public Role_user Get([FromQuery]string id)
        {
           var data=  _context.Role_user.Where(a => a.UserId == id).SingleOrDefault();
            return data;
        }

        // POST api/<RoleUserController>
        [HttpPost]
        public void Post(Role_user role_)
        {
            ///说明存在数据
            if (_context.Role_user.Where(a => a.UserId == role_.UserId).Count() > 0)
            {
                var data = _context.Role_user.Where(a => a.UserId == role_.UserId).SingleOrDefault();
                data.RoleId = role_.RoleId;
                _context.Role_user.Update(data);
            }
            else
            {
                role_.Id = Guid.NewGuid().ToString();

                role_.Status = "1";
                _context.Role_user.Add(role_);
            }
           
            _context.SaveChanges();
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
