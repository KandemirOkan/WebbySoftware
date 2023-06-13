using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.WebDev;

namespace WebbySoftware.Application.WebOperations.Commands.CreateWebApp{

    public class CreateWebAppCommand{


        public WebDevModel Model {get; set;}
        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public CreateWebAppCommand (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){

            var WebApp = _dbContext.WebApps.SingleOrDefault(x=>x.ProjectName == Model.ProjectName);
            if (WebApp is not null)
            {
                throw new InvalidOperationException("Web App already exists in the database.");
            }

            WebApp = _mapper.Map<WebDev>(Model);
            _dbContext.WebApps.Add(WebApp);
            _dbContext.SaveChanges();
    }

    }


    public class WebDevModel{

        public string ProjectName;
        public string ProjectDescription;
        public List<string> Thumbnails;
        public string ProjectGitLink;
        public string ProjectWebpage;

    }


}