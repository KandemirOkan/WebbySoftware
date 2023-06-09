using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.GameDev;
using WebbySoftware.Entity.User;

namespace WebbySoftware.Application.GameOperations.Commands.UpdateGame{

    public class UpdateGameCommand{

        public UpdateGameModel Model {get; set;}
        public int GameID {get; set;}

        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateGameCommand (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){

            var Game = _dbContext.Games.SingleOrDefault(x=>x.ID == GameID);
            if (Game is not null)
            {
                throw new InvalidOperationException(ErrorMessages.NotFoundID);
            }

            if (_dbContext.Games.Any(x=>x.ProjectName.ToLower() == Model.ProjectName.ToLower() && x.ID != GameID))
            {
                throw new InvalidOperationException (ErrorMessages.ReplicateError);
            }

            Game = _mapper.Map<GameDev>(Model);
            _dbContext.Games.Update(Game);
            _dbContext.SaveChanges();
        }
    }


    public class UpdateGameModel{

        public string ProjectName {get; set;}
        public string ProjectDescription {get; set;}
        public List<string> Thumbnails {get; set;}
        public string ProjectGitLink {get; set;}
        public List<UserDev> Users {get; set;}
        public List<string> GameTags { get; set; }

    }
}