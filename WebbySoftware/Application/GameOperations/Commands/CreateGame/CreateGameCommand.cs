using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.GameDev;
using WebbySoftware.Entity.UserDev;

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

            var Game = _dbContext.Games.SingleOrDefault(x=>x.ProjectName == Model.ProjectName);
            if (Game is not null)
            {
                throw new InvalidOperationException("Game already exists in the database.");
            }

            Game = _mapper.Map<GameDev>(Model);
            _dbContext.Games.Add(Game);
            _dbContext.SaveChanges();
        }
    }


    public class GameDevModel{

        public string ProjectName {get; set;}
        public string ProjectDescription {get; set;}
        public List<string> Thumbnails {get; set;}
        public string ProjectGitLink {get; set;}
        public List<User> Users {get; set;}

    }
}