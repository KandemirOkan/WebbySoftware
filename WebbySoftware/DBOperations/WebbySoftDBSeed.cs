using WebbySoftware.Entity;
using WebbySoftware.DBOperations;
using Microsoft.EntityFrameworkCore;
using WebbySoftware.Entity.GameDev;
using WebbySoftware.Entity.WebDev;
using WebbySoftware.Entity.MobileDev;
using WebbySoftware.Entity.DesktopDev;
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

            if (context.Users.Any())
            {
                return;
            }
            else
            {
                var hakan = new UserDev
                {
                    Name = "Hakan",
                    Surname = "Yildiz",
                    Title = "Co-founder",
                    Email = "yildizhakan88@gmail.com",
                    Phone = "+905367849327",
                    Photo = "~/assets/img/team/HakanYildiz.png",
                    GithubLink = "https://github.com/Hakkology",
                    LinkedINLink = "https://www.linkedin.com/in/hakan-yildiz-029845132/"
                };

                var okan = new UserDev
                {
                    Name = "Okan",
                    Surname = "Kandemir",
                    Title = "Co-founder",
                    Email = "okan-kan@hotmail.com",
                    Phone = "+905372771839",
                    Photo = "~/assets/img/team/OkanKandemir.png",
                    GithubLink = "https://github.com/KandemirOkan",
                    LinkedINLink = "https://www.linkedin.com/in/okan-kandemir-77427014b/"
                };

                context.Users.AddRange(hakan, okan);
                context.SaveChanges();
            }

            var hakanUser = context.Users.Single(u => u.Name == "Hakan");
            var okanUser = context.Users.Single(u => u.Name == "Okan");

            if (context.Games.Any())
            {
                return;
            } 
            else
            {
                var game1 = new GameDev
                {
                    ProjectName = "OpenGL-Framework",
                    ProjectDescription = "Game Engine written from scratch using Open-GL. More details can be found on github page.",
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
                    ProjectDescription = "Runner Game made by Unity. Object Pooling and Procedural Content Generation exercises along with a few game mechanics.",
                    ProjectGitLink = "https://github.com/Hakkology/Stack-the-Cubes",
                    Thumbnails = new List<string> {
                        "~/assets/img/thumbnails/GameDev/StackTheCubes/STC1.png",
                        "~/assets/img/thumbnails/GameDev/StackTheCubes/STC2.png",
                        "~/assets/img/thumbnails/GameDev/StackTheCubes/STC3.png",
                    },
                    GameTags = new List<string>  {
                        "unity", "c#"
                    },
                    GameDevs = new List<UserGameDev>
                    {
                        new UserGameDev
                        {
                            Users = hakanUser
                        }
                    }
                };

                var game3 = new GameDev
                {
                    ProjectName = "Under the Rift's Shadow",
                    ProjectDescription = "Unity RPG game prototype. Village simulation with workers running around with NavMesh. Dialogue options. Enemies and a very simple attack. Using random free assets and mixamo animations and a live world.",
                    ProjectGitLink = "https://github.com/Hakkology/Under-the-Rift-s-Shadow",
                    Thumbnails = new List<string> {
                        "~/assets/img/thumbnails/GameDev/UnderRiftShadow/Rift1.png",
                        "~/assets/img/thumbnails/GameDev/UnderRiftShadow/Rift2.png",
                        "~/assets/img/thumbnails/GameDev/UnderRiftShadow/Rift3.png",
                        "~/assets/img/thumbnails/GameDev/UnderRiftShadow/Rift4.png",
                        "~/assets/img/thumbnails/GameDev/UnderRiftShadow/Rift5.png"
                    },
                    GameTags = new List<string>  {
                        "unity", "c#"
                    },
                    GameDevs = new List<UserGameDev>
                    {
                        new UserGameDev
                        {
                            Users = hakanUser
                        }
                    }
                };

                var game4 = new GameDev
                {
                    ProjectName = "Terrain Test",
                    ProjectDescription = "Unity Terrain generation prototype. Creating a beautiful biome with terrain tools. Navmesh critter controls. Three attack combo animation. Using random free assets and mixamo animations.",
                    ProjectGitLink = "https://github.com/Hakkology/Terrain-Character-Animation-Studies",
                    Thumbnails = new List<string> {
                        "~/assets/img/thumbnails/GameDev/Terrain/Ter1.png",
                        "~/assets/img/thumbnails/GameDev/Terrain/Ter2.png",
                        "~/assets/img/thumbnails/GameDev/Terrain/Ter3.png"
                    },
                    GameTags = new List<string>  {
                        "unity", "c#"
                    },
                    GameDevs = new List<UserGameDev>
                    {
                        new UserGameDev
                        {
                            Users = hakanUser
                        }
                    }
                };

                context.Games.AddRange(game1, game2, game3, game4);
            }

            if (context.WebApps.Any())
            {
                return;
            }
            else
            {
                var web1 = new WebDev
                {
                    ProjectName = "E-Commerce Website",
                    ProjectDescription = "Using a free template, creation of a 5 layer E-Commerce website. Connected to MSSQL database. User login, register and basket features.",
                    ProjectGitLink = "https://github.com/Hakkology/E-Commerce-Website",
                    Thumbnails = new List<string> {
                        "~/assets/img/thumbnails/WebDev/ECommerceWebsite/Vekproj1.png",
                        "~/assets/img/thumbnails/WebDev/ECommerceWebsite/Vekproj2.png",
                        "~/assets/img/thumbnails/WebDev/ECommerceWebsite/Vekproj3.png",
                        "~/assets/img/thumbnails/WebDev/ECommerceWebsite/Vekproj4.png",
                    },
                    WebTags = new List<string>  {
                        "c#", "aspnet","commerce"
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

                var web2 = new WebDev
                {
                    ProjectName = "E-CommerceWebsite-2",
                    ProjectDescription = "Using a free template, creation of a 5 layer E-Commerce website. Connected to MSSQL database. User login, register and basket features. More detailed outline categories.",
                    ProjectGitLink = "https://github.com/KandemirOkan/E-Commerce-Website",
                    Thumbnails = new List<string> {
                        "~/assets/img/thumbnails/WebDev/HepsiOrada/HepsiOrada2.png",
                        "~/assets/img/thumbnails/WebDev/HepsiOrada/HepsiOrada3.png",
                        "~/assets/img/thumbnails/WebDev/HepsiOrada/HepsiOradaHomePage.png"
                    },
                    WebTags = new List<string>  {
                        "c#", "aspnet","commerce"
                    },
                    WebDevs = new List<UserWebDev>
                    {
                        new UserWebDev
                        {
                            Users = okanUser
                        },
                    }
                };

                var web3 = new WebDev
                {
                    ProjectName = "Bookstore-WebApi",
                    ProjectDescription = "Creation of a web-api that functions as a bookstore. ",
                    ProjectGitLink = "https://github.com/KandemirOkan/BookStoreWebApi",
                    Thumbnails = new List<string> {
                        "~/assets/img/thumbnails/WebDev/Bookstore/BookStore_Web_Api.png"
                    },
                    WebTags = new List<string>  {
                        "c#", "webapi"
                    },
                    WebDevs = new List<UserWebDev>
                    {
                        new UserWebDev
                        {
                            Users = okanUser
                        },
                    }
                };

                context.WebApps.AddRange(web1, web2, web3);
            }

            if (context.DesktopApps.Any())
            {
                return;
            }
            else
            {
                var desk1 = new DesktopDev
                {
                    ProjectName = "Currency-Converter",
                    ProjectDescription = "Desktop application retrieves real-time exchange rates from the Central Bank of Turkey.",
                    ProjectGitLink = "https://github.com/KandemirOkan/Form_App_CurrencyConversion",
                    Thumbnails = new List<string> {
                        "~/assets/img/thumbnails/WebDev/CurrencyConverter/Currency_Converter_App.png"
                    },
                    DeskTags = new List<string>  {
                        "c#", "aspnet"
                    },
                    DeskDevs = new List<UserDeskDev>
                    {
                        new UserDeskDev
                        {
                            Users = okanUser
                        },
                    }
                };
                context.DesktopApps.AddRange(desk1);
            }

            context.SaveChanges();
        }
    }
}
