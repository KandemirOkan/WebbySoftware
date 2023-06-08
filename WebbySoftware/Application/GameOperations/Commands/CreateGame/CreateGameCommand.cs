using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.GameDevModel;

namespace WebbySoftware.Application.Commands.CreateGame{

    public class CreateGameCommand{
        public GameDevModel Model {get; set;}
        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public CreateGameCommand (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper _ mapper;
        }

        public void Handle(){

            var Game = _dbContext.Gam
        }
    }


    public class GameDevModel{

        public string ProjectName;
        public string ProjectDescription;
        public List<string> Thumbnails;
        public string ProjectGitLink;

        public string ProjectDownloadLink;

    }
}