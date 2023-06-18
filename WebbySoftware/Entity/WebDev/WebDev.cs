using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using WebbySoftware.Entity;

namespace WebbySoftware.Entity.WebDev {
    public class WebDev : IBaseAtrributes, IProjectModule, IWebDev {

        //base attributes
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        //common attributes
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public List<string> Thumbnails { get; set; }
        public string ProjectGitLink { get; set; }

        // specific attributes
        public string ProjectWebpage { get; set; }

        // Many to many relationship
        public ICollection<UserWebDev> UserWebDevs { get; set; }

        public WebDev() {

            CreationDate= DateTime.Now;
            UpdateDate= DateTime.Now;
            Active = true;
            Deleted = false;
        }
    }
}
