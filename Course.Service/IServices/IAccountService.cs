
using Course.Repository.ViewModeles;
using Microsoft.AspNetCore.Http;

namespace Course.Service.IServices {
    public interface IAccountService {
        Task<bool> RegsiterForm(RegisterViewModel model);
        Task<bool> LoginForm(LoginViewModel model);
        Task<bool> ForgetPassword(ForgetPasswordViewModel model);
        Task<bool> Logout();
        Task<AddRoleViewModel> AddRole(string Name);
        Task<AddRoleViewModel> DeleteRole(string Name);
        Task<IEnumerable<RolesViewModel>> GetRoles();
        Task<AddRoleViewModel> GetRoleById(string Id);
        Task<IList<string>> UserInRole(string roleName);
        Task<UpdateRoleViewModel> UpdateRole(string Id, string roleName);
        Task<IList<UsersInfoViewModel>> UsersInRole(string roleName);
        Task<bool> UpdateUsersInRole(UsersInRoleViewModel model);
        Task<ProfileUserViewModel> ProfileUser(string email);
        Task<bool> UpdateUserInfo(IFormFile file, string Username,string email);
        Task<bool> UpdateUserSocial(string Fb, string Twtter, string insgram,string LIn, string email);
        Task<bool> UpdateUserAbout(string about, string email);
        Task<IList<ProfessorInfoViewModel>> GetProfessors(int currentPage, int pageSize);
    }
}
