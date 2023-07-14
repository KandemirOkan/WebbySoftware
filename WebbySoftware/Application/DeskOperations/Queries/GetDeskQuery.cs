using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.DesktopDev;
using WebbySoftware.Entity.User;

namespace WebbySoftware.Application.DeskOperations.Queries{

    public class GetDeskQuery{

        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetDeskQuery (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<DeskDevViewModel> Handle(){

            var deskList = _dbContext.DesktopApps
                .Include(g => g.DeskDevs)
                    .ThenInclude(ug => ug.Users)
                .OrderBy(g => g.ID)
                .ToList();

            return _mapper.Map<List<DeskDevViewModel>>(deskList);
        }

        public List<DeskDevViewModel> Handle(string searchedTag)
        {
            var gameList = _dbContext.DesktopApps
                .Include(g => g.DeskDevs)
                    .ThenInclude(ug => ug.Users)
                .Where(g => g.DeskTags.Contains(searchedTag) 
                            || g.ProjectName.Contains(searchedTag)
                            || g.DeskDevs.Any(d => d.Users.Name.Contains(searchedTag))) // Filter based on associated user names
                .OrderBy(g => g.ID)
                .ToList();

            return _mapper.Map<List<DeskDevViewModel>>(gameList);
        }
    }


    public class DeskDevViewModel
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public List<string> Thumbnails { get; set; }
        public string ProjectGitLink { get; set; }
        public List<string> DeskTags { get; set; }
        public List<UserDeskDevViewModel> Users { get; set; }
    }

    public class UserDeskDevViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}