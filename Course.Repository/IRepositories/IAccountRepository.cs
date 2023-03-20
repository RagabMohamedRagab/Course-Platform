
using Course.Domain.Domains;
using Course.Repository.ViewModeles;

namespace Course.Repository.IRepositories {
    public interface IAccountRepository {
          Task<bool> Add(RegisterViewModel entity);
        Task<bool> Login(LoginViewModel entity);
        Task<bool> ForgetPassword(ForgetPasswordViewModel model); 
    }
}
