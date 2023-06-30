using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.User;

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

            var MobileApp = _dbContext.MobileApps
                .Include(g => g.MobileDevs)
                    .ThenInclude(ug => ug.Users)
                .OrderBy(g => g.ID)
                .SingleOrDefault(x=>x.ID == MobileAppID);
                
            return _mapper.Map<MobileAppIdModel>(MobileApp);

        }
    }


    public class MobileAppIdModel{

        public string ProjectName {get; set;}
        public string ProjectDescription {get; set;}
        public List<string> Thumbnails {get; set;}
        public string ProjectGitLink {get; set;}
        public string ProjectLink {get; set;}
        public List<string> MobileAppTags { get; set; }
        public List<UserDev> Users {get; set;}
    }

    public class UserMobileDevViewIdModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}