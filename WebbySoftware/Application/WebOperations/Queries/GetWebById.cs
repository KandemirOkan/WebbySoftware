using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.UserDev;

namespace WebbySoftware.Application.WebOperations.Queries{

    public class GetWebByID{

        public int WebAppID;
        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetWebByID (IWebbySoftDBContext dbContext, IMapper mapper){
            
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GetWebByIDModel Handle(){

            var WebApp = _dbContext.Games.SingleOrDefault(x=>x.ID == WebAppID);
            return _mapper.Map<GetWebByIDModel>(WebApp);

        }
    }


    public class GetWebByIDModel{

        public string ProjectName {get; set;}
        public string ProjectDescription {get; set;}
        public List<string> Thumbnails {get; set;}
        public string ProjectGitLink {get; set;}
        public string ProjectWebpage {get; set;}
        public List<User> Users {get; set;}

    }
}