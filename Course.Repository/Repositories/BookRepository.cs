

using Course.Repository.Context;
using Course.Repository.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace Course.Repository.Repositories {
    public class BookRepository : BaseRepository<Book>, IBookRepository {
        private readonly UserManager<AppUser> _userManager;
        public BookRepository(CourseDbContext course, UserManager<AppUser> userManager) : base(course)
        {
            _userManager = userManager;
        }
        public async Task<string> GetUserByName(string Name)
        {
            if (String.IsNullOrEmpty(Name))
                return string.Empty;
            var user = await _userManager.FindByNameAsync(Name);
            if (user is not null)
                return user.Id;
            return string.Empty;
        }   
        
        public async Task<IList<DisplayAllBooksViewModel>> GetAllBooks(int CurrentPage, int Pagesize)
        {
            int start = ((CurrentPage - 1) * Pagesize),
                end = Pagesize * CurrentPage;

            var books =await GetAll();
           IList<DisplayAllBooksViewModel> booksInfo=new List<DisplayAllBooksViewModel>();
            booksInfo = books.Skip(start).Take(end).Select(b => new DisplayAllBooksViewModel()
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                UserId = b.UserId,
                Cover = (String.IsNullOrEmpty(b.Cover)) ? "../Images/Book/NoBook.png" : "../Images/Book/" + b.Cover,
                book = "../Images/Book/" + b.book
            }).ToList();

           return booksInfo;
        }
    }
}
