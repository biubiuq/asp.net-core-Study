using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asp.NetCoreStudy.db;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Asp.NetCoreStudy
{
    public class Startup
    {
        /// <summary>
        /// 配置
        /// </summary>
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

     
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var connection = Configuration.GetSection("MysqlConnection").Value;
            services.AddDbContext<mysqlContext>(options => options.UseMySql(connection));
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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("")) //签发者密钥
                };
            });
            //将生成token的类注册为单例
         //   services.AddSingleton<IJwtAuthenticationHandler>(new JwtAuthenticationHandler(tokenSecretKey));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
