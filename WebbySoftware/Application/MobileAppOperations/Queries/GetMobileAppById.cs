using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.MobileDev;

namespace WebbySoftware.Application.MobileAppOperations.Queries{

    public class GetMobileAppByID{

        public int MobileAppID;
        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetMobileAppByID (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public MobileAppIdModel Handle(){

            var MobileApp = _dbContext.MobileApps.SingleOrDefault(x=>x.ID == MobileAppID);
            return _mapper.Map<MobileAppIdModel>(MobileApp);

        }
    }


    public class MobileAppIdModel{

        public string ProjectName;
        public string ProjectDescription;
        public List<string> Thumbnails;
        public string ProjectGitLink;
        public string ProjectLink;

    }
}