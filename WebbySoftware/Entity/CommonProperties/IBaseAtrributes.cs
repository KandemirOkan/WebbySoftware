namespace WebbySoftware.Entity {
    public interface IBaseAtrributes {

        //Base Attributes
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    }
}
