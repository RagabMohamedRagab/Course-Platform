

using Course.Repository.IRepositories;
using Course.Repository.ViewModeles;

namespace Course.Service.Services {
    public class SubscribeService : ISubscribeService {
        private readonly ISubscribeRepository _subscribe;

        public SubscribeService(ISubscribeRepository subscribe)
        {
            _subscribe = subscribe;
        }

        public async Task<List<SubscribeViewModel>> GetSubscriptions(string Name)
        {
            return await _subscribe.GetSubscribes(Name);
        }
    }
}
