using AutoMapper;
using WebbySoftware.Entity.GameDev;
using WebbySoftware.Entity.MobileDev;
using WebbySoftware.Entity.WebDev;
using WebbySoftware.Entity.UserDev;

using WebbySoftware.Application.GameOperations.Commands.CreateGame;
using WebbySoftware.Application.GameOperations.Commands.UpdateGame;
using WebbySoftware.Application.GameOperations.Queries;

using WebbySoftware.Application.WebOperations.Commands.CreateWebApp;
using WebbySoftware.Application.WebOperations.Commands.UpdateWebApp;
using WebbySoftware.Application.WebOperations.Queries;

using WebbySoftware.Application.MobileAppOperations.Commands.CreateMobileApp;
using WebbySoftware.Application.MobileAppOperations.Commands.UpdateMobileApp;
using WebbySoftware.Application.MobileAppOperations.Queries;

using WebbySoftware.Application.UserOperations.Queries;
using static WebbySoftware.Application.UserOperations.Commands.CreateUser.CreateUserCommand;


namespace WebbySoftware.Common{

    public class MappingProfile : Profile{

        public MappingProfile(){

            //Map for games
            CreateMap<GameDevModel, GameDev>();
            CreateMap<UpdateGameModel, GameDev>();
            CreateMap<GameDev, GameDevViewModel>();
            CreateMap<GameDev, GameDevViewModel>().ReverseMap();

            //Map for mobile apps
            CreateMap<MobileAppDevModel, MobileDev>();
            CreateMap<UpdateMobileAppModel, MobileDev>();
            CreateMap<MobileDev, MobileAppDevViewModel>();
            CreateMap<MobileDev, MobileAppDevViewModel>().ReverseMap();

            //Map for Web apps
            CreateMap<WebDevModel, WebDev>();
            CreateMap<UpdateWebAppModel, WebDev>();
            CreateMap<WebDev, WebViewModel>();
            CreateMap<WebDev, WebViewModel>().ReverseMap();

            //User maps
            CreateMap<CreateUserModel, User>();
            CreateMap<User, UserViewModel>();
            CreateMap<User, UserViewModel>().ReverseMap();

        }
    }
}