using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.DesktopDev;
using WebbySoftware.Entity.User;

namespace WebbySoftware.Application.DeskOperations.Queries{

    public class GetDeskById{

        public int DeskID;
        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetDeskById (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public DeskDevIdModel Handle(){

            var desk = _dbContext.DesktopApps
                .Include(g => g.DeskDevs)
                    .ThenInclude(ug => ug.Users)
                .OrderBy(g => g.ID)
                .SingleOrDefault(x=>x.ID == DeskID);
                
            return _mapper.Map<DeskDevIdModel>(desk);

        }
    }


    public class DeskDevIdModel{

        public string ProjectName {get; set;}
        public string ProjectDescription {get; set;}
        public List<string> Thumbnails {get; set;}
        public string ProjectGitLink {get; set;}
        public List<string> DeskTags { get; set; }
        public List<UserDeskDevViewIdModel> Users {get; set;}

    }

    public class UserDeskDevViewIdModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}