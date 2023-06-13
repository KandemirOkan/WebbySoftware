using System.Collections.Generic;


namespace WebbySoftware.Entity.UserGameDev
{
    //Product ile Category'nin bağlantısını sağlamak için üretilen ara sınıf
    public class UserGameDev
    {
        public int GameID { get; set; }
        public int UserID { get; set; }
        public virtual GameDev GameDevs { get; set; }
        public virtual User Users { get; set; }  
    }
}