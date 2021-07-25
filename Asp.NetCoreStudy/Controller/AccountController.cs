using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asp.NetCoreStudy.db;
using Asp.NetCoreStudy.jwt;
using Asp.NetCoreStudy.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Study.Application.Dto;
using Study.Application.Response;
using Study.Model;
using Study.Repository.EFRepository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.NetCoreStudy.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IMemoryCache _cache;
        public dbContext _context;
        private IJwtAuthenticationHandler _jwt;
        public AccountController(IJwtAuthenticationHandler jwt, dbContext dbContext, IMemoryCache memoryCache)
        {
            _context = dbContext;
            _cache = memoryCache;
            _jwt = jwt;

        }
        // GET api/<AccountController>/5
        [HttpPost]
        public dynamic Post(User user)
        {
            var user1 = _context.User.Where(a => a.userName == user.userName && a.passWord == user.passWord).SingleOrDefault();
            if (user1 == null)
            {
                return NotFound();
            }
            return _jwt.Authenticate(user.userName, user.passWord);
        }

        // GET api/<AccountController>/5
        [HttpPost]
        public dynamic Login(UserDto user)
        {

            string code = (string)_cache.Get(user.captchaId);
            if (string.IsNullOrWhiteSpace(code)) code = "";
            if(user.captcha.ToLower()!=code.ToLower())
            {
                return "验证码错误";
            }
        //    var user1 = _context.User.Where(a => a.userName == user.userName && a.passWord == user.passWord).SingleOrDefault();
            //if (user1 == null)
            //{
            //    return NotFound();
            //}
            return new UserResponse<Object>() { 
                code=0,
                data=new {
                  token = _jwt.Authenticate(user.userName, user.passWord),
                    user = new
                    {
                        token = "",
                        headerImg= "http://localhost:5000/images/sr1.gif"
                    }
                }
               
            };
       
        }
  
        [HttpPost]
        public dynamic Captcha()
        {
            string str = string.Empty;
            string code1=string.Empty;
            using (var stream = VerifyCodeHelper.Create(out string code,6))
            {
                var buffer = stream.ToArray();
                str = Convert.ToBase64String(buffer);
                code1 = code;


            }
            string guid = Guid.NewGuid().ToString();
            _cache.Set(guid, code1,DateTimeOffset.Now.AddMinutes(15));
            str = "data:image/png;base64," + str;
            return new { 
              data= new {
                  captchaId= guid,
                  picPath= str
              },
              code=0
            };
        }

       
    }
}
