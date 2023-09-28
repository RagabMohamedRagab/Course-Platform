namespace Course.dashboard.Areas.UI.Repositories {
    public interface ICartRepository {
        Task<bool> Add(int Id,string UName,string type);

        Task<CheckoutViewModel> Checkout( string uname,int Cpage=1,int Psize=4,decimal discount=0.1m);


        Task<bool> DeleteCart(int id, string uname);
     
    }
}
