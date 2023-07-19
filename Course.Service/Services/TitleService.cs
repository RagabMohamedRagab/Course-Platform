using AutoMapper;
using Course.Domain.Domains;
using Course.Repository.IRepositories;
using Course.Repository.ViewModeles;
using Course.Service.Utilities;
using System.Collections.Generic;

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
        public async Task<UpdateTitleViewModel> GetTitleById(int id)
        {
            var titleVM =await _titleRepository.Find(b => b.Id == id);
            return _mapper.Map<UpdateTitleViewModel>(titleVM);
        }
        public async Task<bool> UpdateTitle(UpdateTitleViewModel model)
        {
            var title = await _titleRepository.Find(b => b.Id == model.Id);
            if (title is null)
                return false;
            title.Name = model.Name;
            title.Price = model.Price;
            if (model.file is null)
            {
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            if(await _fileService.RemoveFile(title.Logo, Utitity.Title))
            {
                 if(await _fileService.UploadFile(model.file, Utitity.Title))
                {
                    title.Logo = model.file.FileName;
                    await _unitOfWork.SaveChangesAsync();
                    return true;
                }
            }
            return false;
                 
        }
        public async Task<List<TitleDropDownListViewModel>> GetAll()
        {
            var Titles = await _titleRepository.GetAll();
            
            return _mapper.Map<List<TitleDropDownListViewModel>>(Titles);
        }

        public async Task<DisplayTitlesViewModel> GetAllTitles(int currentPage, string userName, string Search = "", string order = "")
        {
            var displayTitles = new DisplayTitlesViewModel();
            //Get UserId By Name
            var userId=await _titleRepository.GetUserByName(userName);
            if(userId is null)
            {
                displayTitles.IsCompleted = false;
                return displayTitles;
            }
          // Get All Titles
            var getTitles = await _titleRepository.GetAll();
            if (!getTitles.Any())
            {
                displayTitles.IsCompleted = false;
                return displayTitles;
            }
           //GetAllTitles Based On UserId
           getTitles = getTitles.Where(t => t.AppUserId == userId);
            // Order By Price
            var orderBy = order ?? "ASC";
            if (orderBy == "ASC")
            {
                getTitles = getTitles.OrderBy(b => b.Price);
            }else if (orderBy == "DESC")
            {
                getTitles = getTitles.OrderByDescending(b => b.Price);
            }
            // Search By
            var searchBy = Search ?? null;
            if (!String.IsNullOrEmpty(searchBy))
                getTitles = getTitles.Where(s => s.Name == searchBy || s.Name.ToLower().Contains(searchBy.ToLower()));
            if (!getTitles.Any())
            {
                 displayTitles.IsCompleted=false;
                displayTitles.Orderby = orderBy;
                displayTitles.SearchBy = searchBy;
                return displayTitles;
            }
            // GetAll by PageSize And PageNumber
            int totalRecords = getTitles.Count();
            int pageSize = 6;
            int totalPage = (int)Math.Ceiling(totalRecords / (double)pageSize);
            getTitles = getTitles.Skip((currentPage - 1) * pageSize).Take(pageSize);
              // Get all Titles
            displayTitles.Titles = _mapper.Map<List<TitlesViewModel>>(getTitles);
            displayTitles.PageSize=pageSize;
            displayTitles.CurrentPage = currentPage;
            displayTitles.TotalPages = totalPage;
            displayTitles.IsCompleted=true;
            displayTitles.Orderby=orderBy;
            displayTitles.SearchBy=searchBy;
            
            return displayTitles;
        }

        public async Task<bool> DeleteTitle(int Id)
        {
            var title =await _titleRepository.Find(b => b.Id == Id);
            if (title == null)
            {
                return false;
            }
          await  _titleRepository.Delete(title);
            if (await _unitOfWork.SaveChangesAsync() > 0)
            {
                if ( await _fileService.RemoveFile(title.Logo,Utitity.Title))
                    return true;
            }

            return false;
        }
    }
}
