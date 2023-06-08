using WebbySoftware.Entity;
using Microsoft FrameworkCore;

namespace WebbySoftware.DBOperations{

    public interface IWebbySoftDBContext{

        public DbSet<GameDev> Games { get; set; }
        public DbSet<MobileDev> MobileApps { get; set; }
        public DbSet<WebDev> WebApps { get; set; }

        int SaveChanges();
    }
}