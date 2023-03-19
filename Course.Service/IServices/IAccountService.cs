
using Course.Repository.ViewModeles;

namespace Course.Service.IServices {
    public interface IAccountService {
        Task<bool> RegsiterForm(RegisterViewModel model);
        Task<bool> LoginForm(LoginViewModel model);
    }
}
