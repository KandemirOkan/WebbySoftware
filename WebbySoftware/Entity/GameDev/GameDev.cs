using WebbySoftware.Entity.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebbySoftware.Entity.GameDev
{
    public class GameDev: BaseAtrributes, ProjectModule, GameDevelopmentInt {

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
        public string ProjectDownloadPath { get; set; }

        public GameDev(string _projectName, string _projectDescription, List<string> _thumbnails, string _projectGitLink, string _projectPath) {
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
            ProjectDownloadPath = _projectPath;
        }
    }
}
