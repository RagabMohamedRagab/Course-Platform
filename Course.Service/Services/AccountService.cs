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
    }
}




