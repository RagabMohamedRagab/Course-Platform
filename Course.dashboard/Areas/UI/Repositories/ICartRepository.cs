namespace Course.dashboard.Areas.UI.Repositories {
    public interface ICartRepository {
        Task<bool> Add(int Id,string UName);
    }
}
