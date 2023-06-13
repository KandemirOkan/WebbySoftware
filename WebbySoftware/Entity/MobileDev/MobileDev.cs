using WebbySoftware.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WebbySoftware.Entity.MobileDev {
    public class MobileDev: IBaseAtrributes, IProjectModule, IMobileDev {

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
        public string ProjectLink { get; set; }

        public ICollection<UserMobileDev> UserMobileDevs { get; set; }

        public MobileDev(string _projectName, string _projectDescription, string _projectVersion, List<string> _thumbnails, string _projectGitLink, string _projectLink, string _projectPath) {

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
            ProjectLink = _projectLink;

        }
    }
}
