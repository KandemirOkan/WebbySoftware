using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.DesktopDev;
using WebbySoftware.Entity.User;

namespace WebbySoftware.Application.DeskOperations.Commands.CreateDesk{

    public class CreateDeskCommand{
        public DeskDevModel Model {get; set;}
        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public CreateDeskCommand (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){

            var desk = _dbContext.DesktopApps.SingleOrDefault(x=>x.ProjectName == Model.ProjectName);
            if (desk is not null)
            {
                throw new InvalidOperationException(ErrorMessages.ReplicateError);
            }

            desk = _mapper.Map<DesktopDev>(Model);
            _dbContext.DesktopApps.Add(desk);
            _dbContext.SaveChanges();
        }
    }



    public class DeskDevModel{

        public string ProjectName {get; set;}
        public string ProjectDescription {get; set;}
        public List<string> Thumbnails {get; set;}
        public string ProjectGitLink {get; set;}
        public List<UserDev> Users {get; set;}
        public List<string> DeskTags { get; set; }

    }
}