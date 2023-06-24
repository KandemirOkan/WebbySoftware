using System.Collections.Generic;
using WebbySoftware.Entity.User;


namespace WebbySoftware.Entity.WebDev
{
    //Product ile Category'nin bağlantısını sağlamak için üretilen ara sınıf
    public class UserWebDev
    {
        public int WebAppID { get; set; }
        public int UserID { get; set; }
        public virtual WebDev WebDevs { get; set; }
        public virtual UserDev Users { get; set; }  
    }
}