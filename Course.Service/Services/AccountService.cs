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

        public async Task<int> RegsiterForm(RegisterViewModel model)
        {
            if (await _accountRepository.Add(model) > 0)
            {
                return 1;
            }
            return 0;
        }
    }
}




