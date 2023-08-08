
using Course.Repository.ViewModeles;

namespace Course.Service.IServices {
    public interface IHomeService {
        public Task<DisplayDataInHomeViewModel> Index();
    }
}
