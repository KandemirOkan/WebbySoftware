using WebbySoftware.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace WebbySoftware.DBOperations{

    public class WebbySoftDbContext : DbContext, IWebbySoftDBContext
    {
        public WebbySoftDbContext(DbContextOptions<WebbySoftDbContext options) : base(options){

        }
        
        // Define DbSet properties for each of your models
        public DbSet<GameDevelopmentModel> GameDevelopmentModels { get; set; }
        public DbSet<MobileDevelopmentModel> MobileDevelopmentModels { get; set; }
        public DbSet<WebDevelopmentModel> WebDevelopmentModels { get; set; }

        public override int SaveChanges(){

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }

}


