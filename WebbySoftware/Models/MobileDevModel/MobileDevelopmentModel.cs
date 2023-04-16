using WebbySoftware.Models.Interfaces;

namespace WebbySoftware.Models.MobileDevModel {
    public class MobileDevelopmentModel: BaseAtrributes, ProjectModule, MobileAppDevelopmentInt {

        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectVersion { get; set; }
        public List<string> Thumbnails { get; set; }
        public string ProjectGitLink { get; set; }
        public string ProjectDownloadLink { get; set; }
        public string ProjectDownloadPath { get; set; }

        public MobileDevelopmentModel(string _projectName, string _projectDescription, string _projectVersion, List<string> _thumbnails, string _projectGitLink, string _projectLink, string _projectPath) {

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
            ProjectDownloadLink = _projectLink;
            ProjectDownloadPath = _projectPath;

        }
    }
}
