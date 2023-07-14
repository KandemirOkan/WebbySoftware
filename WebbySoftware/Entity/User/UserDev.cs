using System.ComponentModel.DataAnnotations.Schema;
using WebbySoftware.Entity.GameDev;
using WebbySoftware.Entity.MobileDev;
using WebbySoftware.Entity.WebDev;
using WebbySoftware.Entity.DesktopDev;
using System.Collections.Generic;

namespace WebbySoftware.Entity.User
{
    public class UserDev
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public string GithubLink { get; set; }
        public string LinkedINLink { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }
        public string? RefreshToken { get; set; }


        public ICollection<UserGameDev> GameDevs { get; set; }
        public ICollection<UserWebDev> WebDevs { get; set; }
        public ICollection<UserMobileDev> MobileDevs { get; set; }
        public ICollection<UserDeskDev> DeskDevs { get; set; }

        public UserDev()
        {
            GameDevs = new List<UserGameDev>();
            WebDevs = new List<UserWebDev>();
            MobileDevs = new List<UserMobileDev>();
            DeskDevs = new List <UserDeskDev>();
        }

    }
}