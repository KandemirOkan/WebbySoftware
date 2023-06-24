using AutoMapper;
using WebbySoftware.Entity.GameDev;
using WebbySoftware.Entity.MobileDev;
using WebbySoftware.Entity.WebDev;
using WebbySoftware.Entity.User;

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
using WebbySoftware.Application.UserOperations.Commands.UpdateUser;
using static WebbySoftware.Application.UserOperations.Commands.CreateUser.CreateUserCommand;


namespace WebbySoftware.Common{

    public class MappingProfile : Profile{

        public MappingProfile(){

            //Map for games
            CreateMap<GameDevModel, GameDev>();
            CreateMap<UpdateGameModel, GameDev>();
            CreateMap<GameDev, GameDevViewModel>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.GameDevs.Select(ug => ug.Users).ToList()));

            //Map for mobile apps
            CreateMap<MobileAppDevModel, MobileDev>();
            CreateMap<UpdateMobileAppModel, MobileDev>();
            CreateMap<MobileDev, MobileAppDevViewModel>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.MobileDevs.Select(ug => ug.Users).ToList()));

            //Map for Web apps
            CreateMap<WebDevModel, WebDev>();
            CreateMap<UpdateWebAppModel, WebDev>();
            CreateMap<WebDev, WebViewModel>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.WebDevs.Select(ug => ug.Users).ToList()));

            //User maps
            CreateMap<CreateUserModel, UserDev>();
            CreateMap<UpdateUserModel, UserDev>();
            CreateMap<UserDev, UserViewModel>();
            CreateMap<UserDev, UserGameDevViewModel>();
            CreateMap<UserDev, UserMobileDevViewModel>();
            CreateMap<UserDev, UserWebDevViewModel>();
        }
    }
}