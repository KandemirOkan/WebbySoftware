using AutoMapper;
using WebbySoftware.Application.GameOperations.Commands.CreateGame;
using WebbySoftware.Application.GameOperations.Commands.UpdateGame;
using WebbySoftware.Application.GameOperations.Queries;
using WebbySoftware.Application.GameOperations.Commands.CreateGame;
using WebbySoftware.Application.GameOperations.Commands.UpdateGame;
using WebbySoftware.Application.GameOperations.Queries;
using WebbySoftware.Application.GameOperations.Commands.CreateGame;
using WebbySoftware.Application.GameOperations.Commands.UpdateGame;
using WebbySoftware.Application.GameOperations.Queries;
using WebbySoftware.Entity.GameDevModel;
using WebbySoftware.Entity.MobileDevModel;
using WebbySoftware.Entity.WebDevModel;

namespace WebbySoftware.Common{

    public class MappingProfile : Profile{

        public MappingProfile(){

            CreateMap <CreateGame, GameDevelopmentModel>();

            CreateMap <GameDevelopmentModel, Game


        }
    }
}