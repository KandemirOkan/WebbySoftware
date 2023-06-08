using WebbySoftware.DBOperations;


namespace WebbySoftware.Application.GameOperations.Commands.DeleteGame{

    public class DeleteGameCommand{

        private readonly IWebbySoftDBContext _dbContext;
        public int GameID{get;set;}

        public DeleteGameCommand(IWebbySoftDBContext dbContext){

            _dbContext = dbContext;
        }

        public void Handle(){

            var Game = _dbContext.Games.Where(x=>x.ID == GameID).SingleOrDefault();
            if (Game is null)
            {
                throw new InvalidOperationException ("You entered an invalid ID Number");
            }

            _dbContext.Games.Remove(Game);
            _dbContext.SaveChanges();

        }
    }
}
