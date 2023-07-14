using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.MobileDev;
using WebbySoftware.Entity.User;

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
                throw new InvalidOperationException(ErrorMessages.NotFoundID);
            }

            if (_dbContext.MobileApps.Any(x=>x.ProjectName.ToLower() == Model.ProjectName.ToLower() && x.ID != MobileAppID))
            {
                throw new InvalidOperationException (ErrorMessages.ReplicateError);
            }

            MobileApp = _mapper.Map<MobileDev>(Model);
            _dbContext.MobileApps.Update(MobileApp);
            _dbContext.SaveChanges();
        }
    }


    public class UpdateMobileAppModel{

        public string ProjectName {get; set;}
        public string ProjectDescription {get; set;}
        public List<string> Thumbnails {get; set;}
        public string ProjectGitLink {get; set;}
        public string ProjectLink {get; set;}
        public List<string> MobileAppTags { get; set; }
        public List<UserDev> Users {get; set;}

    }
}