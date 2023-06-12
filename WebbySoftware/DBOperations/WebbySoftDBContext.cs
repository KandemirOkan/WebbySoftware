using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebbySoftware.Entity.GameDev;
using WebbySoftware.Entity.MobileDev;
using WebbySoftware.Entity.WebDev;
using WebbySoftware.Entity.User;

namespace WebbySoftware.DBOperations
{
    public class WebbySoftDbContext : DbContext, IWebbySoftDBContext
    {
        public WebbySoftDbContext(DbContextOptions<WebbySoftDbContext> options) : base(options)
        {

        }
        
        // Define DbSet properties for each of your models
        public DbSet<GameDev> Games { get; set; }
        public DbSet<MobileDev> MobileApps { get; set; }
        public DbSet<WebDev> WebApps { get; set; }

        public DbSet<User> Users {get;set;}

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
