using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Asp.NetCoreStudy
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string tokenSecretKey = "123456789123456789"; //加密的密钥
            services.AddControllers();
            services.AddAuthentication(config =>
            {
                //认证方案设置为Jwt
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;  //保存token
                config.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,//不验证签发人
                    ValidateAudience = false,  //不验证听众
                    ValidateIssuerSigningKey = true, //验证签发者密钥
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSecretKey)) //签发者密钥
                };
            });
            //将生成token的类注册为单例
            services.AddSingleton<IJwtAuthenticationHandler>(new JwtAuthenticationHandler(tokenSecretKey));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
         
            app.Use((content, next) => {

                //证件单元
                var claims = new List<Claim>()
{
                new Claim(ClaimTypes.Name,"奥巴马"),
                new Claim(ClaimTypes.NameIdentifier,"身份证号")
};
                
                   //使用证件单元创建一张身份证
                   //AuthenticationType 对应不同的验证方式
                   var identity = new ClaimsIdentity(claims, "AuthenticationTypeXXX");
                //创建一个人携带cookie身份证
                var identityPrincipal = new ClaimsPrincipal(identity);

                //奥巴马开始过安检

           


                return next.Invoke();
            });
            //AuthenticationManager  验证类
            ///AuthenticationScheme ///身份验证方案
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
