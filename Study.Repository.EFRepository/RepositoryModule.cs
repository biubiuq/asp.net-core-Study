using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Study.Repository.EFRepository
{
 public   static class  RepositoryModule
    {
        public static IServiceCollection AddMyRepository(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetSection("MysqlConnection").Value;
            services.AddDbContext<dbContext>(options => options.UseMySql(connection));
            return services;
        }
    }
}
