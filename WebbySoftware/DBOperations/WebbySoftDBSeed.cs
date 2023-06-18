using WebbySoftware.Entity;
using WebbySoftware.DBOperations;
using Microsoft.EntityFrameworkCore;


public class WebbySoftDBSeed
{
    public static void Initialize (IServiceProvider serviceProvider)
    {
        using (var context = new WebbySoftDbContext(serviceProvider.GetRequiredService<DbContextOptions<WebbySoftDbContext>>())){


            if (context.Games.Any()){
                return;
            }

            context.Games.AddRange(

                new WebbySoftware.Entity.GameDev.GameDev{
                    ProjectName = "Game1",
                    ProjectDescription = "Lorem Ipsum",
                    ProjectGitLink = "https://github.com/Hakkology/OpenGL-Framework"
                    
                },

                    new WebbySoftware.Entity.GameDev.GameDev{
                    ProjectName = "Game2",
                    ProjectDescription = "Lorem Ipsum2",
                    ProjectGitLink = "https://github.com/Hakkology/Stack-the-Cubes"
                    
                }
            );

            context.WebApps.AddRange(

                new WebbySoftware.Entity.WebDev.WebDev{

                    ProjectName = "Web1",
                    ProjectDescription = "Lorem Ipsum web1",
                    ProjectGitLink = "https://github.com/Hakkology/E-Commerce-Website",
                    ProjectWebpage = "www.haberturk.com"
                },
                
                new WebbySoftware.Entity.WebDev.WebDev{

                    ProjectName = "Web2",
                    ProjectDescription = "Lorem Ipsum web2",
                    ProjectGitLink = "https://github.com/Hakkology/Open-AI-Implementation",
                    ProjectWebpage = "www.haberturk.com"
                }
            );

            context.Users.AddRange(
                new WebbySoftware.Entity.UserDev.User{
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
