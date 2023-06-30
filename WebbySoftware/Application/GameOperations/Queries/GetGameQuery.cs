using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.GameDev;
using WebbySoftware.Entity.User;

namespace WebbySoftware.Application.GameOperations.Queries{

    public class GetGameQuery{

        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetGameQuery (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GameDevViewModel> Handle(){

            var gameList = _dbContext.Games
                .Include(g => g.GameDevs)
                    .ThenInclude(ug => ug.Users)
                .OrderBy(g => g.ID)
                .ToList();

            return _mapper.Map<List<GameDevViewModel>>(gameList);
        }

        public List<GameDevViewModel> Handle(string searchedTag)
        {
            var gameList = _dbContext.Games
                .Include(g => g.GameDevs)
                    .ThenInclude(ug => ug.Users)
                .Where(g => g.Tags.Contains(searchedTag))
                .OrderBy(g => g.ID)
                .ToList();

            return _mapper.Map<List<GameDevViewModel>>(gameList);
        }
    }


    public class GameDevViewModel
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public List<string> Thumbnails { get; set; }
        public string ProjectGitLink { get; set; }
        public List<string> Tags { get; set; }
        public List<UserGameDevViewModel> Users { get; set; }
    }

    public class UserGameDevViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}