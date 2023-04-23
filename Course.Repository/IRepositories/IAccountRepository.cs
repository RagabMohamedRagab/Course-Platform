
using Course.Domain.Domains;
using Course.Repository.ViewModeles;

namespace Course.Repository.IRepositories {
    public interface IAccountRepository {
          Task<bool> Add(RegisterViewModel entity);
        Task<bool> Login(LoginViewModel entity);
        Task<bool> ForgetPassword(ForgetPasswordViewModel model);
        Task<bool> Logout();
        Task<AddRoleViewModel> AddRole(AddRoleViewModel model);
        Task<AddRoleViewModel> DeleteRole(string Id);
        Task<IEnumerable<RolesViewModel>> GetAllRole();
        Task<AddRoleViewModel> GetRoleById(string Id);
        Task<IList<string>> UserInRole(string roleName);
        Task<bool> UpdateRole(UpdateRoleViewModel model);
        Task<IList<UsersInfoViewModel>> UsersInRole(string roleName);
        Task<bool> UpdateUsersInRole(UsersInRoleViewModel model);
        Task<ProfileUserViewModel> ProfileUser(string email);
        Task<bool> UpdateUserInfo(string photo, string newUser, string email);
        Task<bool> UpdateUserSocial(string Fb, string Twtter, string insgram, string email);
        Task<bool> UpdateUserAbout( string about, string email);
    }
}
