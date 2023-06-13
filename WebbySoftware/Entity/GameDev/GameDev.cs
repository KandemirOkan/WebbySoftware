using WebbySoftware.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WebbySoftware.Entity.GameDev
{
    public class GameDev: IBaseAtrributes, IProjectModule {

        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID {get; set;}
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public List<string> Thumbnails { get; set; }
        public string ProjectGitLink { get; set; }

        public ICollection<UserGameDev> UserGameDevs { get; set; }

        public GameDev(string _projectName, string _projectDescription, List<string> _thumbnails, string _projectGitLink) {
            //base attributes
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            Active = true;
            Deleted = false;

            //common attributes
            ProjectName = _projectName;
            ProjectDescription = _projectDescription;
            Thumbnails = _thumbnails;
            ProjectGitLink = _projectGitLink;

            // specific attributes
        }
    }
}
