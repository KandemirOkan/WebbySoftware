using AutoMapper;
using WebbySoftware.DBOperations;

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

        public string ProjectName;
        public string ProjectDescription;
        public List<string> Thumbnails;
        public string ProjectGitLink;
        public string ProjectWebpage;

    }
}