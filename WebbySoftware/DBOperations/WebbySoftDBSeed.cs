using WebbySoftware.Entity;
using WebbySoftware.DBOperations;
using Microsoft.EntityFrameworkCore;
using WebbySoftware.Entity.GameDev;
using WebbySoftware.Entity.WebDev;
using WebbySoftware.Entity.UserDev;

public class WebbySoftDBSeed
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<WebbySoftDbContext>();

            if (context.Games.Any())
            {
                return;
            }

            context.Games.AddRange(
                new GameDev
                {
                    ProjectName = "Game1",
                    ProjectDescription = "Lorem Ipsum",
                    ProjectGitLink = "https://github.com/Hakkology/OpenGL-Framework"
                },
                new GameDev
                {
                    ProjectName = "Game2",
                    ProjectDescription = "Lorem Ipsum2",
                    ProjectGitLink = "https://github.com/Hakkology/Stack-the-Cubes"
                }
            );

            context.WebApps.AddRange(
                new WebDev
                {
                    ProjectName = "Web1",
                    ProjectDescription = "Lorem Ipsum web1",
                    ProjectGitLink = "https://github.com/Hakkology/E-Commerce-Website",
                    ProjectWebpage = "www.haberturk.com"
                },
                new WebDev
                {
                    ProjectName = "Web2",
                    ProjectDescription = "Lorem Ipsum web2",
                    ProjectGitLink = "https://github.com/Hakkology/Open-AI-Implementation",
                    ProjectWebpage = "www.haberturk.com"
                }
            );

            context.Users.AddRange(
                new User
                {
                    Name = "Hakan",
                    Surname = "Yildiz",
                    Email = "yildizhakan88@gmail.com",
                    Password = "1234"
                }
            );

            context.SaveChanges();
        }
    }
}
