using WebbySoftware.Entity.GameDev;
using WebbySoftware.Entity.MobileDev;
using WebbySoftware.Entity.WebDev;
using WebbySoftware.Entity.DesktopDev;
using WebbySoftware.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace WebbySoftware.DBOperations
{

    public interface IWebbySoftDBContext{

        public DbSet<GameDev> Games { get; set; }
        public DbSet<MobileDev> MobileApps { get; set; }
        public DbSet<WebDev> WebApps { get; set; }
        public DbSet<DesktopDev> DesktopApps {get; set;}

        public DbSet<UserDev> Users {get;set;}

        public DbSet<UserGameDev> GameDevs {get;set;}
        public DbSet<UserWebDev> WebDevs {get;set;}
        public DbSet<UserMobileDev> MobileDevs {get;set;}
        public DbSet<UserDeskDev> DeskDevs {get;set;}

        int SaveChanges();
    }
}