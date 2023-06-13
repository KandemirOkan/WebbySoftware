using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebbySoftware.Entity.GameDev;
using WebbySoftware.Entity.MobileDev;
using WebbySoftware.Entity.WebDev;
using WebbySoftware.Entity.UserDev;

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

        public DbSet<UserGameDev> UserGameDevs {get;set;}
        public DbSet<UserWebDev> UserWebDevs {get;set;}
        public DbSet<UserMobileDev> UserMobileDevs {get;set;}

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserGameDev>()
                .HasKey(ug => new { ug.GameID, ug.UserID });

            modelBuilder.Entity<UserGameDev>()
                .HasOne(ug => ug.Users)
                .WithMany(u => u.UserGameDevs)
                .HasForeignKey(ug => ug.UserID);

            modelBuilder.Entity<UserGameDev>()
                .HasOne(ug => ug.GameDevs)
                .WithMany(g => g.UserGameDevs)
                .HasForeignKey(ug => ug.GameID);

            modelBuilder.Entity<UserMobileDev>()
                .HasKey(um => new { um.MobileAppID, um.UserID });

            modelBuilder.Entity<UserMobileDev>()
                .HasOne(um => um.MobileDevs)
                .WithMany(u => u.UserMobileDevs)
                .HasForeignKey(um => um.MobileAppID);

            modelBuilder.Entity<UserMobileDev>()
                .HasOne(um => um.Users)
                .WithMany(m => m.UserMobileDevs)
                .HasForeignKey(um => um.MobileAppID);

            modelBuilder.Entity<UserWebDev>()
                .HasKey(uw => new { uw.UserID, uw.WebAppID });

            modelBuilder.Entity<UserWebDev>()
                .HasOne(uw => uw.Users)
                .WithMany(u => u.UserWebDevs)
                .HasForeignKey(uw => uw.UserID);

            modelBuilder.Entity<UserWebDev>()
                .HasOne(uw => uw.WebDevs)
                .WithMany(w => w.UserWebDevs)
                .HasForeignKey(uw => uw.WebAppID);
                }
            }
}
