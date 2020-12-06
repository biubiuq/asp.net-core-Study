using Microsoft.EntityFrameworkCore;
using Study.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Study.Extension
{
    public class mysqlContext : DbContext
    {
        public mysqlContext(DbContextOptions<mysqlContext> options) : base(options)
        {

        }

          public DbSet<User> Movies { get; set; }
    }
}
