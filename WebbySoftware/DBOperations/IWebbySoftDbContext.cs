using WebbySoftware.Entity.GameDev;
using WebbySoftware.Entity.MobileDev;
using WebbySoftware.Entity.WebDev;
using WebbySoftware.Entity.UserDev;
using Microsoft.EntityFrameworkCore;

namespace WebbySoftware.DBOperations
{

    public interface IWebbySoftDBContext{

        public DbSet<GameDev> Games { get; set; }
        public DbSet<MobileDev> MobileApps { get; set; }
        public DbSet<WebDev> WebApps { get; set; }

        public DbSet<User> Users {get;set;}

        public DbSet<UserGameDev> UserGameDevs {get;set;}
        public DbSet<UserWebDev> UserWebDevs {get;set;}
        public DbSet<UserMobileDev> UserMobileDevs {get;set;}

        int SaveChanges();
    }
}