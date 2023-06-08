using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.MobileDev;

namespace WebbySoftware.Application.MobileAppOperations.Commands.UpdateMobileApp{

    public class UpdateMobileAppCommand{

        public UpdateMobileAppModel Model {get; set;}
        public int MobileAppID {get; set;}

        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateMobileAppCommand (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){

            var MobileApp = _dbContext.MobileApps.SingleOrDefault(x=>x.ID == MobileAppID);
            if (MobileApp is not null)
            {
                throw new InvalidOperationException("Mobile App ID cannot be found");
            }

            if (_dbContext.Games.Any(x=>x.ProjectName.ToLower() == Model.ProjectName.ToLower() && x.ID != MobileAppID))
            {
                throw new InvalidOperationException ("This game is registered with a different ID Number");
            }

            MobileApp = _mapper.Map<MobileDev>(Model);
            _dbContext.MobileApps.Update(MobileApp);
            _dbContext.SaveChanges();
        }
    }


    public class UpdateMobileAppModel{

        public string ProjectName;
        public string ProjectDescription;
        public List<string> Thumbnails;
        public string ProjectGitLink;
        public string ProjectLink;

    }
}