using WebbySoftware.DBOperations;


namespace WebbySoftware.Application.UserOperations.Commands.DeleteUser{

    public class DeleteUserCommand{

        private readonly IWebbySoftDBContext _dbContext;
        public int UserID{get;set;}

        public DeleteUserCommand(IWebbySoftDBContext dbContext){

            _dbContext = dbContext;
        }

        public void Handle(){

            var User = _dbContext.Users.Where(x=>x.Id == UserID).SingleOrDefault();
            if (User is null)
            {
                throw new InvalidOperationException (ErrorMessages.NotFoundID);
            }

            _dbContext.Users.Remove(User);
            _dbContext.SaveChanges();

        }
    }
}