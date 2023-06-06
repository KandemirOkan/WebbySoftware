using WebbySoftware.Entity;
using Microsoft FrameworkCore;

namespace WebbySoftware.DBOperations{

    public interface IWebbySoftDBContext{

        public DbSet<GameDevelopmentModel> GameDevelopmentModels { get; set; }
        public DbSet<MobileDevelopmentModel> MobileDevelopmentModels { get; set; }
        public DbSet<WebDevelopmentModel> WebDevelopmentModels { get; set; }

        int SaveChanges();
    }
}