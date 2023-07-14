using System.Collections.Generic;
using WebbySoftware.Entity.User;

namespace WebbySoftware.Entity.DesktopDev
{
    public class UserDeskDev
    {
        public int DeskID { get; set; }
        public int UserID { get; set; }
        public virtual DesktopDev DeskDevs { get; set; }
        public virtual UserDev Users { get; set; }  
    }
}
