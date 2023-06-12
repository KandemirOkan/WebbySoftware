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
using static WebbySoftware.Application.UserOperations.Commands.CreateUser.CreateUserCommand;


namespace WebbySoftware.Common{

    public class MappingProfile : Profile{

        public MappingProfile(){

            //Map for games
            CreateMap<GameDevModel, GameDev>();
            CreateMap<UpdateGameModel, GameDev>();
            CreateMap<GameDev, GameDevViewModel>()
            .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => (src.ProjectName).ToString()));

            //Map for mobile apps
            CreateMap<MobileAppDevModel, MobileDev>();
            CreateMap<UpdateMobileAppModel, MobileDev>();
            CreateMap<MobileDev, MobileAppDevViewModel>()
            .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => (src.ProjectName).ToString()));

            //Map for Web apps
            CreateMap<WebDevModel, WebDev>();
            CreateMap<UpdateWebAppModel, WebDev>();
            CreateMap<WebDev, WebViewModel>()
            .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => (src.ProjectName).ToString()));

            //User maps
            CreateMap<CreateUserModel, User>();
            CreateMap<User, UserViewModel>()
            .ForMember(dest=>dest.Name, opt=>opt.MapFrom(src => (src.Name).ToString()))
            .ForMember(dest=>dest.Id, opt=>opt.MapFrom(src => (src.Id)));

        }
    }
}