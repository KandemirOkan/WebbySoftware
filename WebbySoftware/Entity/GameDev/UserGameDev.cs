using System.Collections.Generic;
using WebbySoftware.Entity.User;

namespace WebbySoftware.Entity.GameDev
{
    public class UserGameDev
    {
        public int GameID { get; set; }
        public int UserID { get; set; }
        public virtual GameDev GameDevs { get; set; }
        public virtual UserDev Users { get; set; }  
    }
}
