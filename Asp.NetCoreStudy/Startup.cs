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
            string tokenSecretKey = "123456789123456789"; //���ܵ���Կ
            services.AddControllers();
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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSecretKey)) //ǩ������Կ
                };
            });
            //������token����ע��Ϊ����
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

                //֤����Ԫ
                var claims = new List<Claim>()
{
                new Claim(ClaimTypes.Name,"�°���"),
                new Claim(ClaimTypes.NameIdentifier,"���֤��")
};
                
                   //ʹ��֤����Ԫ����һ�����֤
                   //AuthenticationType ��Ӧ��ͬ����֤��ʽ
                   var identity = new ClaimsIdentity(claims, "AuthenticationTypeXXX");
                //����һ����Я��cookie���֤
                var identityPrincipal = new ClaimsPrincipal(identity);

                //�°���ʼ������

           


                return next.Invoke();
            });
            //AuthenticationManager  ��֤��
            ///AuthenticationScheme ///�����֤����
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
