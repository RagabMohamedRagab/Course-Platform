using Course.Repository.IRepositories;
using Course.Repository.ViewModeles;
namespace Course.Service.Services {
    public class AccountService : IAccountService {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;

        public AccountService(IUnitOfWork unitOfWork, IAccountRepository accountRepository)
        {
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
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
    }
}




