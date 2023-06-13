using AutoMapper;
using Course.Domain.Domains;
using Course.Repository.IRepositories;
using Course.Repository.ViewModeles;
using Course.Service.Utilities;

namespace Course.Service.Services {
    public class TitleService : ITitleService {
        private readonly ITitleRepository _titleRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public TitleService(ITitleRepository titleRepository, IMapper mapper, IUnitOfWork unitOfWork, IFileService fileService)
        {
            _titleRepository = titleRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<bool> Create(TitleFormViewModel model)
        {
            try
            {
                var title = _mapper.Map<Title>(model);
                var userId = await _titleRepository.GetUserByName(model.AppUserId);
                if (userId is not null &&await _fileService.UploadFile(model.Logo, Utitity.Title))
                {
                    title.Logo = model.Logo.FileName;
                    title.AppUserId=userId;
                    await _titleRepository.Add(title);
                    if (await _unitOfWork.SaveChangesAsync() > 0)
                        return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<List<TitleDropDownListViewModel>> GetAll()
        {
            var Titles = await _titleRepository.GetAll();
            return _mapper.Map<List<TitleDropDownListViewModel>>(Titles);
        }
    }
}
