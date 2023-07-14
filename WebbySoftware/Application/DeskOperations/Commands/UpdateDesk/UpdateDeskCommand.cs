using AutoMapper;
using WebbySoftware.DBOperations;
using WebbySoftware.Entity.DesktopDev;
using WebbySoftware.Entity.User;

namespace WebbySoftware.Application.DeskOperations.Commands.UpdateDesk{

    public class UpdateDeskCommand{

        public UpdateDeskModel Model {get; set;}
        public int DeskID {get; set;}

        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateDeskCommand (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){

            var desk = _dbContext.DesktopApps.SingleOrDefault(x=>x.ID == DeskID);
            if (desk is not null)
            {
                throw new InvalidOperationException(ErrorMessages.NotFoundID);
            }

            if (_dbContext.DesktopApps.Any(x=>x.ProjectName.ToLower() == Model.ProjectName.ToLower() && x.ID != DeskID))
            {
                throw new InvalidOperationException (ErrorMessages.ReplicateError);
            }

            desk = _mapper.Map<DesktopDev>(Model);
            _dbContext.DesktopApps.Update(desk);
            _dbContext.SaveChanges();
        }
    }


    public class UpdateDeskModel{

        public string ProjectName {get; set;}
        public string ProjectDescription {get; set;}
        public List<string> Thumbnails {get; set;}
        public string ProjectGitLink {get; set;}
        public List<UserDev> Users {get; set;}
        public List<string> DeskTags { get; set; }

    }
}