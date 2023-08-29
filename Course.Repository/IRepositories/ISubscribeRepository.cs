
namespace Course.Repository.IRepositories {
    public interface ISubscribeRepository:IBaseRepository<Subscribe> {
       Task<List<SubscribeViewModel>> GetSubscribes(string Name);
    }
}
