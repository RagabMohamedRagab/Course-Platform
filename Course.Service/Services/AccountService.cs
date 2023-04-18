using Course.Repository.IRepositories;
using Course.Repository.ViewModeles;
using Course.Service.Utilities;
using Microsoft.AspNetCore.Http;

namespace Course.Service.Services {
    public class AccountService : IAccountService {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;
        private readonly IFileService _fileService;

        public AccountService(IUnitOfWork unitOfWork, IAccountRepository accountRepository, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
            _fileService = fileService;
        }

        public Task<bool> ForgetPassword(ForgetPasswordViewModel model)
        {
            return _accountRepository.ForgetPassword(model);
        }

        public async Task<bool> LoginForm(LoginViewModel model)
        {
            return await _accountRepository.Login(model);
        }

        public async Task<bool> Logout()
        {
            return await _accountRepository.Logout();
        }

        public async Task<bool> RegsiterForm(RegisterViewModel model)
        {
            return await _accountRepository.Add(model); 
            
        }
        public async Task<IEnumerable<RolesViewModel>> GetRoles()
        {
            var Roles =await _accountRepository.GetAllRole();
            return Roles is null ? null : Roles;
        }
        public async Task<AddRoleViewModel> AddRole(string Name)
        {
            AddRoleViewModel model = new AddRoleViewModel()
            {
                Name = Name
            };
            var result = await _accountRepository.AddRole(model);
            return result is null ? null:result;
        }
       public async Task<AddRoleViewModel> DeleteRole(string Name)
        {
            var result =await _accountRepository.DeleteRole(Name);
            return result;
        }
        public async Task<AddRoleViewModel> GetRoleById(string Id)
        {
            var result = await _accountRepository.GetRoleById(Id);
            return result is null ? null : result;
        }
        public async Task<IList<string>> UserInRole(string roleName)
        {
            var roleUsers = await _accountRepository.UserInRole(roleName);
            return roleUsers == null ? null : roleUsers;
        }
        public async Task<UpdateRoleViewModel> UpdateRole(string Id, string roleName)
        {
            if (String.IsNullOrEmpty(Id) || String.IsNullOrEmpty(roleName))
            {
                return null;
            }
            UpdateRoleViewModel mod = new UpdateRoleViewModel()
            {
                Id = Id,
                Name = roleName
            };
            return await _accountRepository.UpdateRole(mod) ? mod : null;
        }
        public async  Task<IList<UsersInfoViewModel>> UsersInRole(string roleName)
        {
            if (String.IsNullOrEmpty(roleName))
            {
                return null;
            }
            var result = await _accountRepository.UsersInRole(roleName);
            return await _accountRepository.UsersInRole(roleName) is null ? null : result;
        }
        public async Task<bool> UpdateUsersInRole(UsersInRoleViewModel model)
        {
            return await _accountRepository.UpdateUsersInRole(model) ? true : false;
        }
        public async Task<ProfileUserViewModel> ProfileUser(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                return null;
            }
            var result= await _accountRepository.ProfileUser(email);
            return result is null ? null : result;
        }
        public async Task<bool> UpdateUserInfo(IFormFile file, string Username)
        {
           if(await _fileService.UploadFile(file, "Images\\Profile"))
            {
               
            }
            return false;
        }
    }
}




