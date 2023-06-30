using WebbySoftware.Entity;
using WebbySoftware.DBOperations;
using Microsoft.EntityFrameworkCore;
using WebbySoftware.Entity.GameDev;
using WebbySoftware.Entity.WebDev;
using WebbySoftware.Entity.User;
using System;
using System.Collections.Generic;

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

            var hakan = new UserDev
            {
                Name = "Hakan",
                Surname = "Yildiz",
                Title = "Co-founder",
                Email = "yildizhakan88@gmail.com",
                Password = "1234",
                Photo = "~/assets/img/team/HakanYıldız.png",
                GithubLink = "https://github.com/Hakkology",
                LinkedINLink = "https://www.linkedin.com/in/hakan-yildiz-029845132/"
            };

            var okan = new UserDev
            {
                Name = "Okan",
                Surname = "Kandemir",
                Title = "Co-founder",
                Email = "okan-kan@hotmail.com",
                Password = "1234",
                Photo = "~/assets/img/team/OkanKandemir.png",
                GithubLink = "https://github.com/KandemirOkan",
                LinkedINLink = "https://www.linkedin.com/in/okan-kandemir-77427014b/"
            };

            context.Users.AddRange(hakan, okan);
            context.SaveChanges();

            var hakanUser = context.Users.Single(u => u.Name == "Hakan");
            var okanUser = context.Users.Single(u => u.Name == "Okan");

            var game1 = new GameDev
            {
                ProjectName = "OpenGL-Framework",
                ProjectDescription = "OpenGL-Framework Description",
                ProjectGitLink = "https://github.com/Hakkology/OpenGL-Framework",
                Thumbnails = new List<string>
                {
                    "~/assets/img/thumbnails/GameDev/OpenGL-Framework/OpenGL1.png",
                    "~/assets/img/thumbnails/GameDev/OpenGL-Framework/OpenGL2.png",
                    "~/assets/img/thumbnails/GameDev/OpenGL-Framework/OpenGL4.png",
                    "~/assets/img/thumbnails/GameDev/OpenGL-Framework/OpenGL5.png"
                },
                GameTags = new List<string>  {
                    "opengl", "c++"
                },
                GameDevs = new List<UserGameDev>
                {
                    new UserGameDev
                    {
                        Users = hakanUser
                    }
                }
            };

            var game2 = new GameDev
            {
                ProjectName = "Stack the Cubes",
                ProjectDescription = "Runner Game made by Unity",
                ProjectGitLink = "https://github.com/Hakkology/Stack-the-Cubes",
                Thumbnails = new List<string> {
                    "~/assets/img/thumbnails/GameDev/StackTheCubes/STC1.png",
                    "~/assets/img/thumbnails/GameDev/StackTheCubes/STC2.png",
                    "~/assets/img/thumbnails/GameDev/StackTheCubes/STC3.png",
                },
                GameTags = new List<string>  {
                    "uniy", "c#"
                },
                GameDevs = new List<UserGameDev>
                {
                    new UserGameDev
                    {
                        Users = hakanUser
                    }
                }
            };

            var web1 = new WebDev
            {
                ProjectName = "Web1",
                ProjectDescription = "Lorem Ipsum web1",
                ProjectGitLink = "https://github.com/Hakkology/E-Commerce-Website",
                ProjectWebpage = "www.haberturk.com",
                WebTags = new List<string>  {
                    "c#", "aspnet","commerce"
                },
                WebDevs = new List<UserWebDev>
                {
                    new UserWebDev
                    {
                        Users = okanUser
                    }
                }
            };

            var web2 = new WebDev
            {
                ProjectName = "Web2",
                ProjectDescription = "Lorem Ipsum web2",
                ProjectGitLink = "https://github.com/Hakkology/Open-AI-Implementation",
                ProjectWebpage = "www.haberturk.com",
                WebTags = new List<string>  {
                    "c#", "aspnet","ai"
                },
                WebDevs = new List<UserWebDev>
                {
                    new UserWebDev
                    {
                        Users = okanUser
                    },
                    new UserWebDev
                    {
                        Users = hakanUser
                    }
                }
            };

            context.Games.AddRange(game1, game2);
            context.WebApps.AddRange(web1, web2);
            context.SaveChanges();
        }
    }
}
