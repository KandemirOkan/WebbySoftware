using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.GameDev;
using WebbySoftware.Entity.User;

namespace WebbySoftware.Application.GameOperations.Queries{

    public class GetGameByID{

        public int GameID;
        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetGameByID (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GameDevIdModel Handle(){

            var Game = _dbContext.Games
                .Include(g => g.GameDevs)
                    .ThenInclude(ug => ug.Users)
                .OrderBy(g => g.ID)
                .SingleOrDefault(x=>x.ID == GameID);
                
            return _mapper.Map<GameDevIdModel>(Game);

        }
    }


    public class GameDevIdModel{

        public string ProjectName {get; set;}
        public string ProjectDescription {get; set;}
        public List<string> Thumbnails {get; set;}
        public string ProjectGitLink {get; set;}
        public List<string> Tags { get; set; }
        public List<UserDev> Users {get; set;}

    }

    public class UserGameDevViewIdModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}