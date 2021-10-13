using Manager.Domain.Entities;
using Manager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Context
{
    public class ManagerContext : DbContext
    {
        public ManagerContext()
        {}

        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=172.22.16.1:1433;Database=USERMANAGERAPI;User Id=SA;Password=senhasql!123");
            optionsBuilder.UseSqlServer(@"Data Source=172.22.16.1,1433;Initial Catalog=USERMANAGERAPI;User ID=SA;Password=senhasql!123");
            //Data Source=190.190.200.100,1433;Network Library=DBMSSOCN;Initial Catalog=myDataBase;User ID=myUsername;Password=myPassword;
        }

        public virtual DbSet<User> User {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }


    }
}