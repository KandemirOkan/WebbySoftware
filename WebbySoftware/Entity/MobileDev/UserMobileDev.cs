using System.Collections.Generic;


namespace WebbySoftware.Entity.UserMobileDev
{
    //Product ile Category'nin bağlantısını sağlamak için üretilen ara sınıf
    public class UserMobileDev
    {
        public int MobileAppID { get; set; }
        public int UserID { get; set; }
        public virtual MobileDev MobileDevs { get; set; }
        public virtual User Users { get; set; }  
    }
}