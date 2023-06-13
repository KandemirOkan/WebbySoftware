using System.ComponentModel.DataAnnotations.Schema;
using WebbySoftware.Entity.GameDev;
using WebbySoftware.Entity.MobileDev;
using WebbySoftware.Entity.WebDev;
using System.Collections.Generic;

namespace WebbySoftware.Entity.UserDev
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }
        public string? RefreshToken { get; set; }

        public ICollection<UserGameDev> UserGameDevs { get; set; }
        public ICollection<UserWebDev> UserWebDevs { get; set; }
        public ICollection<UserMobileDev> UserMobileDevs { get; set; }

    }
}