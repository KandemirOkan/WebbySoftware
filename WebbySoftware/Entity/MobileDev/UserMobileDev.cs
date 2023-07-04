using System.Collections.Generic;
using WebbySoftware.Entity.User;

namespace WebbySoftware.Entity.MobileDev
{
    //Product ile Category'nin bağlantısını sağlamak için üretilen ara sınıf
    public class UserMobileDev
    {
        public int MobileAppID { get; set; }
        public int UserID { get; set; }
        public virtual MobileDev MobileDevs { get; set; }
        public virtual UserDev Users { get; set; }  
    }
}