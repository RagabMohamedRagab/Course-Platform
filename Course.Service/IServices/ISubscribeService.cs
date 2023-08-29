
using Course.Repository.ViewModeles;

namespace Course.Service.IServices {
    public interface ISubscribeService {
        Task<List<SubscribeViewModel>> GetSubscriptions(string Name);  
    }
}
