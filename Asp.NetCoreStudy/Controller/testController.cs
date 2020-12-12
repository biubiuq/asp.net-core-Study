using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.NetCoreStudy.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        // GET: api/<testController>
        [HttpGet]
        public async void Get()
        {
            IMediator mediator = HttpContext.RequestServices.GetRequiredService<IMediator>();
            NotyPing notyPing = new NotyPing { Message = "Test Noty" };
            await mediator.Publish(notyPing);
        }

        // GET api/<testController>/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            IMediator mediator = HttpContext.RequestServices.GetRequiredService<IMediator>(); //可以使用依赖注入的方式获得mediator
            Ping ping = new Ping() { Title = "TestTitle" };
            string result = await mediator.Send(ping);
             await HttpContext.Response.WriteAsync(result);
            return result;
        }

        // POST api/<testController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<testController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<testController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
