
using Course.Repository.ViewModeles;

namespace Course.Service.IServices {
    public interface IAccountService {
        Task<bool> RegsiterForm(RegisterViewModel model);
        Task<bool> LoginForm(LoginViewModel model);
        Task<bool> ForgetPassword(ForgetPasswordViewModel model);
        Task<bool> Logout();
        Task<AddRoleViewModel> AddRole(string Name);
        Task<AddRoleViewModel> DeleteRole(string Name);
        Task<IEnumerable<RolesViewModel>> GetRoles();
    }
}
