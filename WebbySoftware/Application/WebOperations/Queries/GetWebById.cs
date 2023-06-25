using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.User;

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

            var WebApp = _dbContext.WebApps
                .Include(g => g.WebDevs)
                    .ThenInclude(ug => ug.Users)
                .OrderBy(g => g.ID)
                .SingleOrDefault(x=>x.ID == WebAppID);
                
            return _mapper.Map<GetWebByIDModel>(WebApp);

        }
    }


    public class GetWebByIDModel{

        public string ProjectName {get; set;}
        public string ProjectDescription {get; set;}
        public List<string> Thumbnails {get; set;}
        public string ProjectGitLink {get; set;}
        public string ProjectWebpage {get; set;}
        public List<UserDev> Users {get; set;}

    }

    public class UserWebDevViewIdModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}