
namespace Course.dashboard.Areas.UI.Repositories {
	public class CourseUIRepository : ICourseUIRepository {
		private readonly CourseDbContext _courseDb;
		private readonly IMapper _mapper;
		public CourseUIRepository(CourseDbContext courseDb, IMapper mapper)
		{
			_courseDb = courseDb;
			_mapper = mapper;
		}

		public async Task<DisplayTitlesViewModel> DisplayTitles( int currentPage, int pageSize,string searchby, string orderby)
		{
			// Get All

			List<Title> allTitles =await _courseDb.Titles.ToListAsync();
		
			var titles = new DisplayTitlesViewModel();
			if (!allTitles.Any())
			{
				titles.IsCompleted = false;
				return titles;
			}
			// Search By

			string key = searchby?? null;
			if(!string.IsNullOrEmpty(key))
			{
				allTitles = allTitles.Where(b => b.Name.ToLower().Contains(key.ToLower())).ToList();
			}
			if(!allTitles.Any())
			{
                titles.IsCompleted = false;
                titles.SearchBy = searchby;
                return titles;
            }
			// Order By
			allTitles = allTitles.OrderBy(b => b.Price).ToList();

			// Take 
			int pSize = pageSize;
            int total = allTitles.Count;
            int totalPage = (int)Math.Ceiling(total / (double)pSize);
			allTitles = allTitles.Skip((currentPage - 1) * pageSize).Take(pSize).ToList();
		


			titles.Titles = _mapper.Map<List<TitlesViewModel>>(allTitles);
			titles.SearchBy = searchby;
			titles.CurrentPage = currentPage;
			titles.PageSize = pageSize;
			titles.TotalPages = totalPage;
			titles.Orderby = orderby;
			titles.IsCompleted = true;
			return titles;
		}
	}
}
