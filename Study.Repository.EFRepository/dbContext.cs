using Microsoft.EntityFrameworkCore;
using Study.Model;

namespace Study.Repository.EFRepository
{

        public class dbContext : DbContext
        {
            public dbContext(DbContextOptions<dbContext> options) : base(options)
            {

            }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<baseType>()
                .HasKey(c => c.baseTypeGuid);
            modelBuilder.Entity<User>()
              .HasKey(c => c.Id);
        }
        public DbSet<User> User { get; set; }
            public DbSet<baseType> baseType { get; set; }

    }
    
}
