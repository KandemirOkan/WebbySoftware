using System.Linq;
using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.User;

namespace WebbySoftware.Application.UserOperations.Queries
{
    public class GetUserQuery
    {
        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserQuery(IWebbySoftDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public List<UserViewModel> Handle()
        {
            var users = _dbContext.Users.ToList<UserDev>();
            List<UserViewModel> rg = _mapper.Map<List<UserViewModel>>(users);
            return rg;
        }
    }
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public string GithubLink { get; set; }
        public string LinkedINLink { get; set; }
    }
}