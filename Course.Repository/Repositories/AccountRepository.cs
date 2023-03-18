
using Course.Domain.Domains;
using Course.Repository.IRepositories;
using Course.Repository.ViewModeles;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Course.Repository.Repositories {
    public class AccountRepository : IAccountRepository {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<int> Add(RegisterViewModel entity)
        {
            AppUser user = new AppUser()
            {
                UserName = entity.Username,
                Email = entity.EmailAddress,
            };
            IdentityResult result = await _userManager.CreateAsync(user, entity.Password);
            if (result.Succeeded)
            {
                string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                await _userManager.ConfirmEmailAsync(user, token);
                await _signInManager.SignInAsync(user, isPersistent: false);
                return 1;
            }
            return 0;
        }





     
    }
}
