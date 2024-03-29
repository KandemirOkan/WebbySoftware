using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.User;

namespace WebbySoftware.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }
        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public CreateUserCommand(IWebbySoftDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Email == Model.Email);
            if (user is not null)
            {
                throw new InvalidOperationException("No registry with that e-mail address in your db.");
            }
            user = _mapper.Map<UserDev>(Model);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public class CreateUserModel
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
}