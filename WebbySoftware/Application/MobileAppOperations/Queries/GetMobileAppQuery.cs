using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.MobileDev;

namespace WebbySoftware.Application.MobileAppOperations.Queries{

    public class GetMobileAppQuery{

        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetGameQuery (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MobileAppDevViewModel> Handle(){

            var MobileAppList = _dbContext.MobileApps.OrderBy(x=>x.ID).ToList<MobileDev>();
            return _mapper.Map<List<MobileAppDevViewModel>>(MobileAppList);

        }
    }


    public class MobileAppDevViewModel{

        public string ProjectName;
        public string ProjectDescription;
        public List<string> Thumbnails;
        public string ProjectGitLink;
        public string ProjectLink;

    }
}