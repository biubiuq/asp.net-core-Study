﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetCoreStudy.db;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Study.Application.Dto;
using Study.Extend.Query;
using Study.Infrastructure.Page;
using Study.Model;
using Study.Repository.EFRepository;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.NetCoreStudy.Controller
{
    [Authorize]   //表示需要认证授权访问
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public dbContext _context;
        public UserController(dbContext dbContext)
        {
            _context = dbContext;
        }
        // GET: api/<UserController>
     
        [HttpGet()]
        public PageResultDto<User> Get([FromQuery] UserDto user)
        {
         
            return _context.User.SourcePage(user);
        }
    
        
        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            value.createDate = DateTime.Now;
            value.Id = Guid.NewGuid().ToString();
            _context.User.Add(value);
            _context.SaveChanges();
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
