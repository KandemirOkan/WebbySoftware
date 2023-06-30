using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.MobileDev;
using WebbySoftware.Entity.User;

namespace WebbySoftware.Application.MobileAppOperations.Commands.CreateMobileApp{

    public class CreateMobileAppCommand{


        public MobileAppDevModel Model {get; set;}
        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public CreateMobileAppCommand (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){

            var MobileApp = _dbContext.MobileApps.SingleOrDefault(x=>x.ProjectName == Model.ProjectName);
            if (MobileApp is not null)
            {
                throw new InvalidOperationException("Mobile App already exists in the database.");
            }

            MobileApp = _mapper.Map<MobileDev>(Model);
            _dbContext.MobileApps.Add(MobileApp);
            _dbContext.SaveChanges();
        }

    }


    public class MobileAppDevModel{

        public string ProjectName {get; set;}
        public string ProjectDescription {get; set;}
        public List<string> Thumbnails {get; set;}
        public string ProjectGitLink {get; set;}
        public string ProjectLink {get; set;}
        public List<string> Tags { get; set; }
        public List<UserDev> Users {get; set;}

    }


}