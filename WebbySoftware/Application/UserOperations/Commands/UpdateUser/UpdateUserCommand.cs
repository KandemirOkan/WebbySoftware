using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.User;

namespace WebbySoftware.Application.UserOperations.Commands.UpdateUser{

    public class UpdateUserCommand{

        public UpdateUserModel Model {get; set;}
        public int UserID {get; set;}

        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateUserCommand (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){

            var User = _dbContext.Users.SingleOrDefault(x=>x.Id == UserID);
            if (User is not null)
            {
                throw new InvalidOperationException("User ID cannot be found");
            }

            if (_dbContext.Users.Any(x=>x.Name.ToLower() == Model.Name.ToLower() && x.Id != UserID))
            {
                throw new InvalidOperationException ("This user is registered with a different ID Number");
            }

            User = _mapper.Map<UserDev>(Model);
            _dbContext.Users.Update(User);
            _dbContext.SaveChanges();
        }
    }


    public class UpdateUserModel{
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Title { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }

    }
}