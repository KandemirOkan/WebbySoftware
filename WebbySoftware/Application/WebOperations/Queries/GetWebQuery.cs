using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.WebDev;
using WebbySoftware.Entity.UserDev;

namespace WebbySoftware.Application.WebOperations.Queries{

    public class GetWebQuery{

        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetWebQuery (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<WebViewModel> Handle(){

            var webList = _dbContext.WebApps.OrderBy(x=>x.ID).ToList<WebDev>();
            return _mapper.Map<List<WebViewModel>>(webList);

        }
    }

    public class WebViewModel{

        public string ProjectName {get; set;}
        public string ProjectDescription {get; set;}
        public List<string> Thumbnails {get; set;}
        public string ProjectGitLink {get; set;}
        public string ProjectWebpage {get; set;}
        public List<User> Users {get; set;}

    }
}