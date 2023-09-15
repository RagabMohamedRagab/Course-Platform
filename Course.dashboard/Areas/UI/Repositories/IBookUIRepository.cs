namespace Course.dashboard.Areas.UI.Repositories {
	public interface IBookUIRepository {
        Task<DisplayBookViewModel> DisplayBooks(int currentPage, int pageSize, string searchby, string orderby);

    }
}
