using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.GameDev;

namespace WebbySoftware.Application.GameOperations.Queries{

    public class GetGameQuery{

        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetGameQuery (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GameDevViewModel> Handle(){

            var gameList = _dbContext.Games.OrderBy(x=>x.ID).ToList<GameDev>();
            return _mapper.Map<List<GameDevViewModel>>(gameList);

        }
    }


    public class GameDevViewModel{

        public string ProjectName;
        public string ProjectDescription;
        public List<string> Thumbnails;
        public string ProjectGitLink;

    }
}