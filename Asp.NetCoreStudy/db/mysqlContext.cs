using Microsoft.EntityFrameworkCore;
using Study.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCoreStudy.db
{
    public class mysqlContext : DbContext
    {
        public mysqlContext(DbContextOptions<mysqlContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
    }
}
