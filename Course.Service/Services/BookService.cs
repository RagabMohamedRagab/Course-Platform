using AutoMapper;
using Course.Domain.Domains;
using Course.Repository.IRepositories;
using Course.Repository.ViewModeles;
using Course.Service.Utilities;

namespace Course.Service.Services {
    public class BookService : IBookService {
        private readonly IBookRepository _bookRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IBookRepository bookRepository, IFileService fileService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _fileService = fileService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(BookFormViewModel model)
        {
            // Save Images
            if (!(await _fileService.UploadFile(model.Cover, Utitity.Book) && await _fileService.UploadFile(model.Book, Utitity.Book)))
                return false;
            var book = _mapper.Map<Book>(model);
            book.Cover = model.Cover.FileName;
            book.book = model.Book.FileName;
            var userId = await _bookRepository.GetUserByName(model.UserName);
            if (userId is null)
                return false;
            book.UserId = userId;
            await _bookRepository.Add(book);
            return await _unitOfWork.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<IList<DisplayAllBooksViewModel>> GetAllAsync(int currentPage, int pageSize)
        {
            if (currentPage <= 0 || pageSize <= 0)
                return null;
            return await _bookRepository.GetAllBooks(currentPage, pageSize);
        }
    }
}
