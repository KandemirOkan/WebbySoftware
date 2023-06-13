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
            CreateMap<GameDevModel, GameDev>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users));
            CreateMap<UpdateGameModel, GameDev>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users));
            CreateMap<GameDev, GameDevViewModel>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users.Select(u => u.Name)));
            CreateMap<GameDev, GameDevViewModel>().ReverseMap();

            //Map for mobile apps
            CreateMap<MobileAppDevModel, MobileDev>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users));
            CreateMap<UpdateMobileAppModel, MobileDev>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users));
            CreateMap<MobileDev, MobileAppDevViewModel>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users.Select(u => u.Name)));
            CreateMap<MobileDev, MobileAppDevViewModel>().ReverseMap();

            //Map for Web apps
            CreateMap<WebDevModel, WebDev>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users));
            CreateMap<UpdateWebAppModel, WebDev>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users));
            CreateMap<WebDev, WebViewModel>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users.Select(u => u.Name)));
            CreateMap<WebDev, WebViewModel>().ReverseMap();

            //User maps
            CreateMap<CreateUserModel, User>();
            CreateMap<User, UserViewModel>()
            .ForMember(dest=>dest.Name, opt=>opt.MapFrom(src => (src.Name).ToString()))
            .ForMember(dest=>dest.Id, opt=>opt.MapFrom(src => (src.Id)))
            .ForMember(dest => dest.Games, opt => opt.MapFrom(src => src.Games.Select(g => g.ProjectName)))
            .ForMember(dest => dest.WebApps, opt => opt.MapFrom(src => src.Games.Select(g => g.ProjectName)))
            .ForMember(dest => dest.MobileApps, opt => opt.MapFrom(src => src.Games.Select(g => g.ProjectName)));
            CreateMap<User, UserViewModel>().ReverseMap();

        }
    }
}