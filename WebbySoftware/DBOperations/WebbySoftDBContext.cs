using Microsoft.EntityFrameworkCore;
using WebbySoftware.Entity.GameDev;
using WebbySoftware.Entity.MobileDev;
using WebbySoftware.Entity.WebDev;
using WebbySoftware.Entity.User;

namespace WebbySoftware.DBOperations
{
    public class WebbySoftDbContext : DbContext, IWebbySoftDBContext
    {
        private readonly IConfiguration configuration;

        public WebbySoftDbContext(DbContextOptions<WebbySoftDbContext> options)
            : base(options)
        {
            
        }

        // Define DbSet properties for each of your models
        public DbSet<GameDev> Games { get; set; }
        public DbSet<MobileDev> MobileApps { get; set; }
        public DbSet<WebDev> WebApps { get; set; }
        public DbSet<UserDev> Users { get; set; }
        public DbSet<UserGameDev> GameDevs { get; set; }
        public DbSet<UserWebDev> WebDevs { get; set; }
        public DbSet<UserMobileDev> MobileDevs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserGameDev>()
                .HasKey(ug => new { ug.GameID, ug.UserID });

            modelBuilder.Entity<UserGameDev>()
                .HasOne(ug => ug.Users)
                .WithMany(u => u.GameDevs)
                .HasForeignKey(ug => ug.UserID);

            modelBuilder.Entity<UserGameDev>()
                .HasOne(ug => ug.GameDevs)
                .WithMany(g => g.GameDevs)
                .HasForeignKey(ug => ug.GameID);

            modelBuilder.Entity<UserMobileDev>()
                .HasKey(um => new { um.MobileAppID, um.UserID });

            modelBuilder.Entity<UserMobileDev>()
                .HasOne(um => um.MobileDevs)
                .WithMany(u => u.MobileDevs)
                .HasForeignKey(um => um.MobileAppID);

            modelBuilder.Entity<UserMobileDev>()
                .HasOne(um => um.Users)
                .WithMany(m => m.MobileDevs)
                .HasForeignKey(um => um.UserID);

            modelBuilder.Entity<UserWebDev>()
                .HasKey(uw => new { uw.UserID, uw.WebAppID });

            modelBuilder.Entity<UserWebDev>()
                .HasOne(uw => uw.Users)
                .WithMany(u => u.WebDevs)
                .HasForeignKey(uw => uw.UserID);

            modelBuilder.Entity<UserWebDev>()
                .HasOne(uw => uw.WebDevs)
                .WithMany(w => w.WebDevs)
                .HasForeignKey(uw => uw.WebAppID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
