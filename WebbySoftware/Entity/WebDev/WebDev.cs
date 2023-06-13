using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using WebbySoftware.Entity;

namespace WebbySoftware.Entity.WebDev {
    public class WebDev : IBaseAtrributes, IProjectModule, IWebDev {

        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public List<string> Thumbnails { get; set; }
        public string ProjectGitLink { get; set; }
        public string ProjectWebpage { get; set; }

        public ICollection<UserWebDev> UserWebDevs { get; set; }

        public WebDev(string _projectName, string _projectDescription, string _projectVersion, List<string> _thumbnails, string _projectGitLink, string _projectWebpage) {

            //base attributes
            CreationDate= DateTime.Now;
            UpdateDate= DateTime.Now;
            Active = true;
            Deleted = false;

            //common attributes
            ProjectName = _projectName;
            ProjectDescription = _projectDescription;
            Thumbnails = _thumbnails;
            ProjectGitLink = _projectGitLink;

            // specific attributes
            ProjectWebpage = _projectWebpage;

        }
    }
}
