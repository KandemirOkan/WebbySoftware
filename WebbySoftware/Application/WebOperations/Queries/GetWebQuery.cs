using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.WebDev;
using WebbySoftware.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace WebbySoftware.Application.WebOperations.Queries{

    public class GetWebQuery{

        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetWebQuery (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<WebViewModel> Handle(){

            var webList = _dbContext.WebApps
                .Include(g => g.WebDevs)
                    .ThenInclude(ug => ug.Users)
                .OrderBy(g => g.ID)
                .ToList();
            return _mapper.Map<List<WebViewModel>>(webList);

        }
    }

    public class WebViewModel{

        public string ProjectName {get; set;}
        public string ProjectDescription {get; set;}
        public List<string> Thumbnails {get; set;}
        public string ProjectGitLink {get; set;}
        public string ProjectWebpage {get; set;}
        public List<UserWebDevViewModel> Users {get; set;}

    }

    public class UserWebDevViewModel
    {
        public string Name { get; set; }
        // Add other properties specific to the UserDevViewModel if needed
    }
}