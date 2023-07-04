using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.GameDev;
using WebbySoftware.Entity.User;

namespace WebbySoftware.Application.GameOperations.Commands.CreateGame{

    public class CreateGameCommand{
        public GameDevModel Model {get; set;}
        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public CreateGameCommand (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){

            var game = _dbContext.Games.SingleOrDefault(x=>x.ProjectName == Model.ProjectName);
            if (game is not null)
            {
                throw new InvalidOperationException(ErrorMessages.ReplicateError);
            }

            game = _mapper.Map<GameDev>(Model);
            _dbContext.Games.Add(game);
            _dbContext.SaveChanges();
        }
    }



    public class GameDevModel{

        public string ProjectName {get; set;}
        public string ProjectDescription {get; set;}
        public List<string> Thumbnails {get; set;}
        public string ProjectGitLink {get; set;}
        public List<UserDev> Users {get; set;}
        public List<string> GameTags { get; set; }

    }
}