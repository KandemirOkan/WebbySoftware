using WebbySoftware.DBOperations;
using AutoMapper;

namespace WebbySoftware.Application.DevOperations.Queries{

    public class GetAllDevelopmentTitles
    {
        private readonly IWebbySoftDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllDevelopmentTitles (IWebbySoftDBContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public DevelopmentViewModel Handle(){

            var gameList = _dbContext.Games
                .OrderBy(g => g.ID)
                .ToList();

            var webList = _dbContext.WebApps
                .OrderBy(w=>w.ID)
                .ToList();

            var mobileList = _dbContext.MobileApps
                .OrderBy(m=>m.ID)
                .ToList();

            var deskList = _dbContext.DeskDevs
                .OrderBy(m=>m.ID)
                .ToList();

            var devList = new DevelopmentViewModel
            {
                GameQuickViewModels = _mapper.Map<List<GameQuickViewModel>>(gameList),
                MobileAppQuickViewModels = _mapper.Map<List<MobileAppQuickViewModel>>(mobileList),
                WebQuickViewModels = _mapper.Map<List<WebQuickViewModel>>(webList),
                DesktopQuickViewModels = _mapper.Map<List<DeskQuickViewModel>>(deskList)
            };
            
            return devList;
        }
    }

    public class DevelopmentViewModel
    {
        public List<GameQuickViewModel> GameQuickViewModels { get; set; }
        public List<MobileAppQuickViewModel> MobileAppQuickViewModels { get; set; }
        public List<WebQuickViewModel> WebQuickViewModels { get; set; }
        public List <DeskQuickViewModel> DesktopQuickViewModels { get; set; }
    }

    public class GameQuickViewModel
    {
        public string ProjectName { get; set; }
        public List<string> Thumbnails { get; set; }
    }

    public class WebQuickViewModel
    {
        public string ProjectName { get; set; }
        public List<string> Thumbnails { get; set; }
    }

    public class MobileAppQuickViewModel
    {
        public string ProjectName { get; set; }
        public List<string> Thumbnails { get; set; }
    }
    public class DeskQuickViewModel
    {
        public string ProjectName { get; set; }
        public List<string> Thumbnails { get; set; }
    }
}