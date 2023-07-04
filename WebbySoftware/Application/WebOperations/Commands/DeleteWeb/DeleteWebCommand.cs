using WebbySoftware.DBOperations;


namespace WebbySoftware.Application.WebOperations.Commands.DeleteWeb{

    public class DeleteWebAppCommand{

        private readonly IWebbySoftDBContext _dbContext;
        public int WebAppID {get;set;}

        public DeleteWebAppCommand(IWebbySoftDBContext dbContext){

            _dbContext = dbContext;
        }

        public void Handle(){

            var WebApp = _dbContext.WebApps.Where(x=>x.ID == WebAppID).SingleOrDefault();
            if (WebApp is null)
            {
                throw new InvalidOperationException (ErrorMessages.NotFoundID);
            }

            _dbContext.WebApps.Remove(WebApp);
            _dbContext.SaveChanges();

        }
    }
}
