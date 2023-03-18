
using Course.Repository.ViewModeles;

namespace Course.Service.IServices {
    public interface IAccountService {
        Task<int> RegsiterForm(RegisterViewModel model); 
    }
}
