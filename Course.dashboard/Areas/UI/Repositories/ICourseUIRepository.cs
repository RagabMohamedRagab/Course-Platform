namespace Course.dashboard.Areas.UI.Repositories {
	public interface ICourseUIRepository {
		Task<DisplayTitlesViewModel> DisplayTitles(int currentPage, int pageSize, string searchby, string orderby );
	}
}
