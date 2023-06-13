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

        public DBSet<UserGameDev> UserGameDevs {get;set;}
        public DBSet<UserWebDev> UserWebDevs {get;set;}
        public DBSet<UserMobileDev> UserMobileDevs {get;set;}

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
                .HasKey(ug => new { ug.UserId, ug.GameDevId });

            modelBuilder.Entity<UserGameDev>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.UserGameDevs)
                .HasForeignKey(ug => ug.UserId);

            modelBuilder.Entity<UserGameDev>()
                .HasOne(ug => ug.GameDev)
                .WithMany(g => g.UserGameDevs)
                .HasForeignKey(ug => ug.GameDevId);

            modelBuilder.Entity<UserMobileDev>()
                .HasKey(um => new { um.UserId, um.MobileDevId });

            modelBuilder.Entity<UserMobileDev>()
                .HasOne(um => um.User)
                .WithMany(u => u.UserMobileDevs)
                .HasForeignKey(um => um.UserId);

            modelBuilder.Entity<UserMobileDev>()
                .HasOne(um => um.MobileDev)
                .WithMany(m => m.UserMobileDevs)
                .HasForeignKey(um => um.MobileDevId);

            modelBuilder.Entity<UserWebDev>()
                .HasKey(uw => new { uw.UserId, uw.WebDevId });

            modelBuilder.Entity<UserWebDev>()
                .HasOne(uw => uw.User)
                .WithMany(u => u.UserWebDevs)
                .HasForeignKey(uw => uw.UserId);

            modelBuilder.Entity<UserWebDev>()
                .HasOne(uw => uw.WebDev)
                .WithMany(w => w.UserWebDevs)
                .HasForeignKey(uw => uw.WebDevId);
                }
            }
}
