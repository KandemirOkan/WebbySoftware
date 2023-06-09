using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.WebDev;

namespace WebbySoftware.Application.WebOperations.Commands.UpdateWebApp{

    public class UpdateWebAppCommand{

        public UpdateWebAppModel Model {get; set;}
        public int WebAppID {get; set;}

        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateWebAppCommand (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){

            var WebApp = _dbContext.WebApps.SingleOrDefault(x=>x.ID == WebAppID);
            if (WebApp is not null)
            {
                throw new InvalidOperationException("Web App ID cannot be found");
            }

            if (_dbContext.WebApps.Any(x=>x.ProjectName.ToLower() == Model.ProjectName.ToLower() && x.ID != WebAppID))
            {
                throw new InvalidOperationException ("This game is registered with a different ID Number");
            }

            WebApp = _mapper.Map<WebDev>(Model);
            _dbContext.WebApps.Update(WebApp);
            _dbContext.SaveChanges();
        }
    }


    public class UpdateWebAppModel{

        public string ProjectName;
        public string ProjectDescription;
        public List<string> Thumbnails;
        public string ProjectGitLink;
        public string ProjectWebpage;

    }
}