﻿namespace WebbySoftware.Models.Interfaces {
    public interface ProjectModule {

        //Attributes common to all Project Modules
        public int ID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectVersion { get; set; }
        public List<string> Thumbnails { get; set; }
        public string ProjectGitLink { get; set; }
            
    }
}