using WebbySoftware.Entity.GameDev;
using WebbySoftware.Entity.MobileDev;
using WebbySoftware.Entity.WebDev;
using Microsoft.EntityFrameworkCore;

namespace WebbySoftware.DBOperations{

    public interface IWebbySoftDBContext{

        public DbSet<GameDev> Games { get; set; }
        public DbSet<MobileDev> MobileApps { get; set; }
        public DbSet<WebDev> WebApps { get; set; }

        int SaveChanges();
    }
}