using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.GameDev;

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

            var Game = _dbContext.Games.SingleOrDefault(x=>x.ID == GameID);
            return _mapper.Map<GameDevIdModel>(Game);

        }
    }


    public class GameDevIdModel{

        public string ProjectName;
        public string ProjectDescription;
        public List<string> Thumbnails;
        public string ProjectGitLink;

    }
}