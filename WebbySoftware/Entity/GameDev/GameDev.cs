using WebbySoftware.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WebbySoftware.Entity.GameDev
{
    public class GameDev: IBaseAtrributes, IProjectModule {

        //base attributes
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        //common attributes
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID {get; set;}
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public List<string>? Thumbnails { get; set; }
        public string ProjectGitLink { get; set; }

        // Many to Many relationship
        public ICollection<UserGameDev> GameDevs { get; set; }

        public GameDev() {
            
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            Active = true;
            Deleted = false;

            GameDevs = new List<UserGameDev>();
        }
    }
}
