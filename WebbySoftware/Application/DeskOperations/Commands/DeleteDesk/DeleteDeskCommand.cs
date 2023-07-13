using WebbySoftware.DBOperations;


namespace WebbySoftware.Application.DeskOperations.Commands.DeleteDesk{

    public class DeleteDeskCommand{

        private readonly IWebbySoftDBContext _dbContext;
        public int DeskID{get;set;}

        public DeleteDeskCommand(IWebbySoftDBContext dbContext){

            _dbContext = dbContext;
        }

        public void Handle(){

            var desk = _dbContext.DeskApps.Where(x=>x.ID == DeskID).SingleOrDefault();
            if (desk is null)
            {
                throw new InvalidOperationException (ErrorMessages.NotFoundID);
            }

            _dbContext.DeskDevs.Remove(desk);
            _dbContext.SaveChanges();

        }
    }
}
