using AutoMapper;
using WebbySoftware.DBOperations;
using Microsoft.EntityFrameworkCore;
using WebbySoftware.Entity.MobileDev;
using WebbySoftware.Entity.User;

namespace WebbySoftware.Application.MobileAppOperations.Queries{

    public class GetMobileAppQuery{

        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetMobileAppQuery (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MobileAppDevViewModel> Handle(){

            var MobileAppList = _dbContext.MobileApps
                .Include(g => g.MobileDevs)
                    .ThenInclude(ug => ug.Users)
                .OrderBy(g => g.ID)
                .ToList();
            return _mapper.Map<List<MobileAppDevViewModel>>(MobileAppList);

        }

        public List<MobileAppDevViewModel> Handle(string searchedTag)
        {
            searchedTag = searchedTag.ToLower();
            var mobileAppList = _dbContext.MobileApps
                .Include(g => g.MobileDevs)
                    .ThenInclude(ug => ug.Users)
                .Where(g => g.MobileAppTags.Contains(searchedTag) 
                            || g.ProjectName.Contains(searchedTag)
                            || g.MobileDevs.Any(d => d.Users.Name.Contains(searchedTag))) // Filter based on associated user names
                .OrderBy(g => g.ID)
                .ToList();

            return _mapper.Map<List<MobileAppDevViewModel>>(mobileAppList);
        }

    }


    public class MobileAppDevViewModel{

        public string ProjectName{get; set;}
        public string ProjectDescription{get; set;}
        public List<string> Thumbnails{get; set;}
        public string ProjectGitLink{get; set;}
        public string ProjectLink{get; set;}
        public List<string> MobileAppTags { get; set; }
        public List<UserMobileDevViewModel> Users{get; set;}

    }
    public class UserMobileDevViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}