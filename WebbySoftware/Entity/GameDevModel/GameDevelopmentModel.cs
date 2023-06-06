using WebbySoftware.Entity.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebbySoftware.Entity.GameDevModel
{
    public class GameDevelopmentModel: BaseAtrributes, ProjectModule, GameDevelopmentInt {

        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID {get; set;}
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectVersion { get; set; }
        public List<string> Thumbnails { get; set; }
        public string ProjectGitLink { get; set; }
        public string ProjectDownloadPath { get; set; }

        public GameDevelopmentModel(string _projectName, string _projectDescription, string _projectVersion, List<string> _thumbnails, string _projectGitLink, string _projectPath) {

            //base attributes
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            Active = true;
            Deleted = false;

            //common attributes
            ProjectName = _projectName;
            ProjectDescription = _projectDescription;
            ProjectVersion = _projectVersion;
            Thumbnails = _thumbnails;
            ProjectGitLink = _projectGitLink;

            // specific attributes
            ProjectDownloadPath = _projectPath;

        }
    }
}
