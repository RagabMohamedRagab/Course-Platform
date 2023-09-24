namespace Course.dashboard.Areas.UI.Repositories {
    public interface ICartRepository {
        Task<bool> Add(int Id,string UName,string type);

        Task<CheckoutViewModel> Checkout(int Cpage,int Psize,decimal discount,string uname);
    }
}
