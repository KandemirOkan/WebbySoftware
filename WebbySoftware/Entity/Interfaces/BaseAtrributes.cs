namespace WebbySoftware.Models.Interfaces {
    public interface BaseAtrributes {

        //Base Attributes
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    }
}
