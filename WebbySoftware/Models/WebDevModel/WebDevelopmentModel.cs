using WebbySoftware.Models.Interfaces;

namespace WebbySoftware.Models.WebDevModel {
    public class WebDevelopmentModel : BaseAtrributes, ProjectModule, WebDevelopmentInt {

        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectVersion { get; set; }
        public List<string> Thumbnails { get; set; }
        public string ProjectGitLink { get; set; }
        public string ProjectWebpage { get; set; }

        public void Add() {
            throw new NotImplementedException();
        }

        public void Delete() {
            throw new NotImplementedException();
        }

        public void Remove() {
            throw new NotImplementedException();
        }

        public void Update() {
            throw new NotImplementedException();
        }

        public WebDevelopmentModel(string _projectName, string _projectDescription, string _projectVersion, List<string> _thumbnails, string _projectGitLink, string _projectWebpage) {

            //base attributes
            CreationDate= DateTime.Now;
            UpdateDate= DateTime.Now;
            Active = true;
            Deleted = false;

            //common attributes
            ProjectName = _projectName;
            ProjectDescription = _projectDescription;
            ProjectVersion = _projectVersion;
            Thumbnails = _thumbnails;
            ProjectGitLink = _projectGitLink;

            // specific attributes
            ProjectWebpage = _projectWebpage;

        }
    }
}
