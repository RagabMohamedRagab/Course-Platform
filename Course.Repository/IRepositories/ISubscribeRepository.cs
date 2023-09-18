
namespace Course.Repository.IRepositories {
    public interface ISubscribeRepository:IBaseRepository<Cart> {
       Task<List<SubscribeViewModel>> GetSubscribes(string Name);
    }
}
