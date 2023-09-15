namespace Course.dashboard.Areas.UI.Repositories {
    public class BookUIRepository : IBookUIRepository {
        private readonly CourseDbContext _courseDb;
        private readonly IMapper _mapper;

        public BookUIRepository(CourseDbContext courseDb, IMapper mapper)
        {
            _courseDb = courseDb;
            _mapper = mapper;
        }


        public async Task<DisplayBookViewModel> DisplayBooks(int currentPage, int pageSize, string searchby, string orderby)
        {
            // Get All

            List<Book> allbooks = await _courseDb.Books.ToListAsync();
            int totla = allbooks.Count();
            var books = new DisplayBookViewModel();
            if (!allbooks.Any())
            {
                books.IsCompleted = false;
                return books;
            }
            // Search By

            string key = searchby ?? null;
            if (!string.IsNullOrEmpty(key))
            {
                allbooks = allbooks.Where(b => b.Name.ToLower().Contains(key.ToLower())).ToList();
            }

            // Order By
            allbooks = allbooks.OrderBy(b => b.Name).ToList();

            // Take 
            int pSize = pageSize;
            int totalPage = (int)Math.Ceiling(totla / (double)pSize);
            allbooks = allbooks.Skip((currentPage - 1) * pageSize).Take(pSize).ToList();



            books.Books = _mapper.Map<List<BookViewModel>>(allbooks);
            books.SearchBy = searchby;
            books.CurrentPage = currentPage;
            books.PageSize = pageSize;
            books.TotalPages = totalPage;
            books.Orderby = orderby;
            books.IsCompleted = true;
            return books;
        }
    }
}
