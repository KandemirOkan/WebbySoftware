using WebbySoftware.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WebbySoftware.Entity.MobileDev {
    public class MobileDev: IBaseAtrributes, IProjectModule, IMobileDev {

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
        public List<string> MobileAppTags { get; set; }

        // specific attributes
        public string ProjectLink { get; set; }

        public ICollection<UserMobileDev> MobileDevs { get; set; }

        public MobileDev() {
            
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            Active = true;
            Deleted = false;

            MobileDevs = new List<UserMobileDev>();
        }
    }
}
