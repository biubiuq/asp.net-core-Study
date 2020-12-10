using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asp.NetCoreStudy.db;
using Asp.NetCoreStudy.jwt;
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
        /// ����
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
            services.AddControllers()
                  .AddNewtonsoftJson(options =>
                  {
                      options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";//����ʱ���ʽ
                  });
            #region ��ӿ���

            #endregion
            services.AddCors(c =>
            {
                c.AddPolicy("Free", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    //.AllowCredentials();//Core3.0֮������Origin��Credentials����������
                });

                c.AddPolicy("limit", policy =>
                {
                    policy.WithOrigins("localhost:8083")
                    .WithMethods("get", "post", "put", "delete")
                    //.WithHeaders("Authorization");
                    .AllowAnyHeader();
                }); 
            });
            var connection = Configuration.GetSection("MysqlConnection").Value;
            services.AddDbContext<mysqlContext>(options => options.UseMySql(connection));
            #region JWT
            string _token = "123456789123456789";
            services.AddAuthentication(config =>
            {
                //��֤��������ΪJwt
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;  //����token
                config.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,//����֤ǩ����
                    ValidateAudience = false,  //����֤����
                    ValidateIssuerSigningKey = true, //��֤ǩ������Կ
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_token)) //ǩ������Կ
                };
            });
            //������token����ע��Ϊ����
            services.AddSingleton<IJwtAuthenticationHandler>(new JwtAuthenticationHandler(_token));
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("Free");
            app.UseAuthentication();//��֤
          
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
