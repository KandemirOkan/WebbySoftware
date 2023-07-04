using WebbySoftware.DBOperations;


namespace WebbySoftware.Application.MobileAppOperations.Commands.DeleteMobileApp{

    public class DeleteMobileAppCommand{

        private readonly IWebbySoftDBContext _dbContext;
        public int MobileAppID{get;set;}

        public DeleteMobileAppCommand(IWebbySoftDBContext dbContext){

            _dbContext = dbContext;
        }

        public void Handle(){

            var MobileApp = _dbContext.MobileApps.Where(x=>x.ID == MobileAppID).SingleOrDefault();
            if (MobileApp is null)
            {
                throw new InvalidOperationException (ErrorMessages.NotFoundID);
            }

            _dbContext.MobileApps.Remove(MobileApp);
            _dbContext.SaveChanges();

        }
    }
}
